# CraftDemo

This demo took me around 6 hours total to complete as I am curently sudying how to make request with c#. I was contenplating on doing this with JS as I familiar with the syntax there but I decied to challenged myself.
I Used the help of stack overflow to get the hang of the request and looking at some code examples from future lectues that I have. I decied to use the httpclient class instead of the httpWeb one as it is what I will be studing soon.
The httpWeb class seemed similar to the JS syntax which tempted me but I decided to leave it for another time. The unit test are currently missing because after a few tries I realized I have kind of forgotten the sytax for them.
I will start looking into it this weekend so I can add them to the git repo. Also there are a few issue that I ran into that I have mentioned below. Please let me know of any way to optimize it as I am sure it is not perfectly written.

## How to Run

1. Clone the repository or download the source code.

2. Open the solution in Visual Studio or navigate to the project directory using the command line.

3. Update the `apiKeyForFreshDesk` variable in the `Main` method of the `StartUp` class with your FreshDesk API key.

4. Build the solution.

5. Run the application.

6. Enter the GitHub username when prompted.

7. Enter the FreshDesk domain when prompted.

8. The application will retrieve the GitHub user information, create a FreshDesk contact, and update the contact if it already exists.

9. Check the console for success or error messages.

## Functionality

The `StartUp` class contains the main entry point of the application.:

- `Main`: Reads the GitHub username and FreshDesk domain from the user, calls various methods to interact with the APIs, and performs the necessary operations.

- `GetGitHubUser`: Makes a GET request to the GitHub API to retrieve the public information of a GitHub user based on the provided username It add the requried UserAgent to the request which you can rename as well
if you plan to change the project name. After which it makes a request using the GetAysnc method provided from the HttpCLient class and depending of the status code proceeds with deserializaing the object and 
returning a `GitHubUser` object or throwing an error.

- `CreateLocalFreshDeskContact`: Creates a `FreshDeskContact` object based on the retrieved GitHub user information and returns it.

- `CreateFreshDeskJson`: Serializes a `FreshDeskContact` object into a JSON string.

- `DoesContactExist`: Checks if a contact already exists in FreshDesk based on the provided email.

- `GetContact`: Retrieves a contact from FreshDesk based on the provided email.

- `CreateFreshDeskContact`: Creates a new contact in FreshDesk using the provided JSON data. Here you can notice a few comments where I tried to add the avatar as well as a byte array but I was not able to properly set up 
the request as I am curently learning how to build them in C# and had to reseearch a lot of things. However I was unable to make it work with an avatar coming from an url.

- `UpdateFreshDeskContact`: Updates an existing contact in FreshDesk using the provided JSON data and contact ID. For this function I was unable to get a good response for some reason. The headers and content type look okay to me
and after struggeling a lot I decied to run it thour an AI and it didn't find any errors as well. I may be missing something obvious here so any advice would be a big help!

- `ImportGitHubUser`: Imports the GitHub user information into a database using Entity Framework Core. This is for the option task for the database as I was unable to create the unit test as I will need some more time to remeber how to write them
for fucntions that make requests. Otherwise here I am using a "FromDto()" Funciton which basiccly converts the object from a dto one to the GitUser class used for the dbcontex. After which I turn off the identity insert so I can add the id explicitly.


-`CraftDemoConfig`

Here we create the schema for the database creation. In the OnConfiguration() function the only thing that I did was add the option to use the SQL connection string porived in the Configuration class

After which I have added a DBSet for the GitHubUser table


-`Configuration`

Here currently there is a const value for the configation string that needs to be changed depending on the SQL server ued.


##Models folder 
- `GitHubUserInfo`

This the is class which I am using to create the table in SQL. I have used data annotations to specify the properties of the fields.
Additionally here lies the "FromDto()" function that converts a DTO object to a GitHubUser object.


##Data Processing 
- `ImportGitUserDto`

Here is the class I am using to convert the json object received from github to a githubuserDTO object which I use to import the user to the table.



##GitGubUser class property description 

    1. UserName: The username of the GitHub user. (string)
    2. Id: The unique ID of the GitHub user. (int)
    3. NodeId: The unique node ID of the GitHub user. (string)
    4. GravatarId: The Gravatar ID of the GitHub user. (string, nullable)
    5. HtmlUrl: The URL to the GitHub user's profile. (string)
    6. Type: The type of the GitHub user. (string)
    7. SiteAdmin: Indicates if the GitHub user is a site admin. (bool)
    8. Name: The name of the GitHub user. (string)
    9. Company: The company associated with the GitHub user. (string, nullable)
    10. Blog: The blog URL of the GitHub user. (string, nullable)
    11. Location: The location of the GitHub user. (string, nullable)
    12. Email: The email address of the GitHub user. (string, nullable)
    13. Hireable: Indicates if the GitHub user is available for hire. (string, nullable)
    14. Bio: The biography of the GitHub user. (string, nullable)
    15. TwitterUsername: The Twitter username of the GitHub user. (string, nullable)
    16. PublicRepos: The number of public repositories owned by the GitHub user. (int)
    17. PublicGists: The number of public gists created by the GitHub user. (int)
    18. Followers: The number of followers of the GitHub user. (int)
    19. Following: The number of users followed by the GitHub user. (int)
    20. CreatedAt: The date and time when the GitHub user account was created. (DateTime)
    21. LastUpdatedAt: The date and time when the GitHub user account was last updated. (DateTime)
    22. AvatarUrl: The URL to the GitHub user's avatar image. (string, nullable)

##FreshDeskContact class property description 

    1. Name: The name of the contact. (string)
    2. Email: The email address of the contact. (string)
    3. TwitterId: The Twitter ID of the contact. (string, nullable)
    4. UniqueExternalId: The unique external ID of the contact. (int)
    5. Address: The address of the contact. (string, nullable)
    6. Description: The description of the contact. (string, nullable)
    7. Id: The ID of the contact. (long)
	


##Unit testing

For now I have added unit tests only for the basic functionality as I still haven't learned mocking and I decided to not blantly copy-paste syntaxis for the mocking untill it works withoit me understanding it.
So I have submitted this for now and will add Mocking tests in the next week or 2


Open for suggestions and advice on how to improve the code! 

	