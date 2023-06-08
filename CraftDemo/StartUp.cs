
using System.Net.Http.Headers;
using System.Text;
using CraftDemo.Database.Data;
using CraftDemo.Database.Data.Models;
using CraftDemo.Database.DataProccessor.ImportDto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;


namespace CraftDemo
{
    internal class StartUp
    {
        static async Task Main(string[] args)
        {
            Console.Write("Enter GitHub Username: ");
            string gitHubUserName = Console.ReadLine();
            Console.Write("Enter FreshDesk Domain: ");
            string freshDeskDomain = Console.ReadLine();
            string apiKeyForFreshDesk = "FreshDesk API Key";

            using (HttpClient client = new HttpClient())
            {

                var gitHubUser = await GetGitHubUser(client, gitHubUserName);//Creating the Git user
                var freshDeskContact = CreateLocalFreshDeskContact(gitHubUser);// Creating the FreshDesk contact
                var contactJson =
                    CreateFreshDeskJson(freshDeskContact); // Generating the JSON string for the Request


                if (await DoesContactExist(client, freshDeskDomain, apiKeyForFreshDesk, freshDeskContact.Email))//If the contact exist go to the update step
                {
                    var freshDeskContactTemp = await GetContact(client, freshDeskDomain, apiKeyForFreshDesk,
                        freshDeskContact.Email);

                    await UpdateFreshDeskContact(client, freshDeskDomain, apiKeyForFreshDesk, contactJson,
                        freshDeskContactTemp.Id);

                }
                else
                {
                   

                    await CreateFreshDeskContact(client, freshDeskDomain, apiKeyForFreshDesk, contactJson);//If it doesn't create it
                }


            }




        }

        //Imports the GitHubUser to the DataBase once he is found. if he is already in there a message will show up on the console
        public static void ImportGitHubUser(string gitHubuserString)
        {
            var contex = new CraftDemoConfig();

            var gitHubUserDto = JsonConvert.DeserializeObject<ImportGitHubUserDto>(gitHubuserString);

            using (contex)
            {
                if (contex.GitHubUserInfo.Any(gu => gu.Id == gitHubUserDto.Id))
                {
                    Console.WriteLine($"GitUser {gitHubUserDto.UserName} is already part of the database");
                }
                else
                {
                    var gitHubUser = GitHubUserInfo.FromDto(gitHubUserDto);
                    contex.Database.OpenConnection();
                    contex.Database.ExecuteSqlRaw("SET IDENTITY_INSERT GitHubUserInfo ON");//Setting this to on so i can add an explicit ID as a primary key
                    contex.Add(gitHubUser);
                    contex.SaveChanges();
                    contex.Database.ExecuteSqlRaw("SET IDENTITY_INSERT GitHubUserInfo OFF");//Turning it off again for safe practice
                }
            }
            
        }

        //Gets the GitHubUser Info
        public static async Task<GitHubUser> GetGitHubUser(HttpClient client, string username)
        {

            //Required header by GitHubs API
            client.DefaultRequestHeaders.UserAgent.ParseAdd("CraftDemo");

            //Getting the public user information
            HttpResponseMessage response = await client.GetAsync($"https://api.github.com/users/{username}");

            if (response.IsSuccessStatusCode)
            {

                //Getting the JSON object as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                //Creating the GitHub user based on the class GitHubUser
                var gitHubUser = JsonConvert.DeserializeObject<GitHubUser>(responseBody);

                //Getting the GitHubAvatar
                HttpResponseMessage imageResponse = await client.GetAsync(gitHubUser.AvatarUrl);

                byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();

                ImportGitHubUser(responseBody); //Adding the GitHubUser to the database

                return gitHubUser;//Cannot be null as if there is no user the request will not come out as successful
            }

            throw new ArgumentException($"Unable to get GitHubUser  Error: {response.StatusCode}");


        }

        //Creates a local fresh desk contact
        public static FreshDeskContact CreateLocalFreshDeskContact(GitHubUser gitHubUser)
        {

            //Creating the FreshDesk use, I will use this to send as a body for the create contact API call
            var newFreshDeskUser = new FreshDeskContact(gitHubUser.UserName, gitHubUser.Email, gitHubUser.TwitterUsername, gitHubUser.Id, gitHubUser.Location, gitHubUser.Bio);


            return newFreshDeskUser;

        }

        //Creates a freshdeshJSON
        public static string CreateFreshDeskJson(FreshDeskContact freshDeskContact)
        {
            //Creating the JSON object
            string contactJson = JsonConvert.SerializeObject(freshDeskContact);

            return contactJson;
        }

        //Creates a freshdesk contact
        public static async Task CreateFreshDeskContact(HttpClient client, string freshDeskDomain, string apiKeyForFreshDesk, string contactJson)
        {

            //Creating multipart form data content

            //MultipartFormDataContent formData = new MultipartFormDataContent();
            //formData.Add(new ByteArrayContent(imageBytes), "avatar", "avatar.jpg");


            //Setting the authentication headers
            //We encode it to a base64 as requested by the documentation for FreshDesk
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKeyForFreshDesk}:x")));//The X here represents the password, as we are using the API key we are not required to enter the user password

            //Creating the body for the request
            var contentForFreshDeskRequest =
                new StringContent(contactJson, Encoding.UTF8, "application/json");


            //Making the post request
            HttpResponseMessage freshDeskResponse =
                await client.PostAsync($"https://{freshDeskDomain}.freshdesk.com/api/v2/contacts", contentForFreshDeskRequest);


            if (freshDeskResponse.IsSuccessStatusCode)
            {
                
                Console.WriteLine("Contact successfully created");
            }
            else
            {
                throw new AggregateException($"Failed to create FresDesk contact. Error: {freshDeskResponse.StatusCode}");
            }


        }

        //Check to see if the contact exists
        public static async Task<bool> DoesContactExist(HttpClient client, string freshDeskDomain, string apiKeyForFreshDesk,
            string email)
        {
            //Setting the authentication headers
            //We encode it to a base64 as requested by the documentation for FreshDesk
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKeyForFreshDesk}:x")));

           HttpResponseMessage response= await client.GetAsync($"https://{freshDeskDomain}.freshdesk.com/api/v2/contacts/?email={email}");


           if (response.IsSuccessStatusCode)
           {
               return true;
           }
           else
           {
               return false;
           }

        }

        //Gets the contact id and name
        public static async Task<FreshDeskContact> GetContact(HttpClient client, string freshDeskDomain,
            string apiKeyForFreshDesk, string email)
        {
            //Setting the authentication headers
            //We encode it to a base64 as requested by the documentation for FreshDesk
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKeyForFreshDesk}:x")));

            HttpResponseMessage response = await client.GetAsync($"https://{freshDeskDomain}.freshdesk.com/api/v2/contacts/?email={email}");

            if (response.IsSuccessStatusCode)
            {

                //Getting the JSON object as a string
                string responseBody = response.Content.ReadAsStringAsync().Result;

                //Creating the GitHub user based on the class GitHubUser
                var freshDeskContact = JsonConvert.DeserializeObject<List<FreshDeskContact>>(responseBody);

                return freshDeskContact[0];
            }

            throw new ArgumentException($"Unable to get FreshDeskUser  Error: {response.StatusCode}");


        }

        //Updates the contact
        public static async Task UpdateFreshDeskContact(HttpClient client, string freshDeskDomain,
            string apiKeyForFreshDesk, string contactJson,long contactId)
        {

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKeyForFreshDesk}:x")));//The X here represents the password, as we are using the API key we are not required to enter the user password

            //Creating the body for the request
            var contentForFreshDeskRequest =
                new StringContent(contactJson, Encoding.UTF8, "application/json");


            //Making the post request
            HttpResponseMessage freshDeskResponse =
                await client.PutAsync($"https://{freshDeskDomain}.freshdesk.com/api/v2/contacts/{contactId}", contentForFreshDeskRequest);


            if (freshDeskResponse.IsSuccessStatusCode)
            {

                Console.WriteLine("Contact successfully updated");
            }
            else
            {
                throw new AggregateException($"Failed to update FresDesk contact. Error: {freshDeskResponse.StatusCode}");
            }

        }
    }
    }

