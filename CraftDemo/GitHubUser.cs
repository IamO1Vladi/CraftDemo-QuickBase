using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CraftDemo
{
    public class GitHubUser
    {

        //public GitHubUser(string username, int id, string nodeId,
        //    string gravatarId, string htmlUrl, string type, bool siteAdmin, string name,
        //    string company, string blog, string location, string email,
        //    string hireable, string bio, string twitterUsername, int publicRepos, int publicGists, int followers,
        //    int following, DateTime createdAt, DateTime updatedAt, string avatarUrl)
        //{
        //    this.UserName = username;
        //    this.Id = id;
        //    this.NodeId = nodeId;
        //    this.GravatarId = gravatarId;
        //    this.HtmlUrl = htmlUrl;
        //    this.Type = type;
        //    this.SiteAdmin = siteAdmin;
        //    this.Name = name;
        //    this.Company = company;
        //    this.Blog = blog;
        //    this.Location = location;
        //    this.Email = email;
        //    this.Hireable = hireable;
        //    this.Bio = bio;
        //    this.TwitterUsername = twitterUsername;
        //    this.PublicRepos = publicRepos;
        //    this.PublicGists = publicGists;
        //    this.Followers = followers;
        //    this.Following = following;
        //    this.CreatedAt = createdAt;
        //    this.LastUpdatedAt = updatedAt;
        //    this.AvatarUrl = avatarUrl;
        //}


        private string _username;
        private string _node_id;
        private string _html_url;
        private string _type;
        private string _name;
        private int _public_repos;
        private int _public_gists;
        private int _followers;
        private int _following;
        private DateTime _updated_at;

        public GitHubUser()
        {

        }

        [JsonProperty("login")]
        public string UserName
        {
            get { return this._username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("UserName cannot be empty");
                }

                this._username = value;
            }
        }
        [JsonProperty("id")]
        public int Id { get; private set; }

        [JsonProperty("node_id")]
        public string NodeId
        {
            get { return this._node_id; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("NodeId cannot be null");
                }

                this._node_id = value;
            }
        }

        [JsonProperty("gravatar_id")]
        public string? GravatarId { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl
        {
            get { return this._html_url; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("HtmlURL cannot be null");
                }

                this._html_url = value;
            }
        }
        [JsonProperty("type")]
        public string Type
        {
            get { return this._type; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Type cannot be null");
                }

                this._type = value;
            }
        }
        [JsonProperty("site_admin")]
        public bool SiteAdmin { get; set; }

        [JsonProperty("name")]
        public string Name
        {
            get { return this._name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name cannot be null");
                }

                this._name = value;
            }
        }

        [JsonProperty("company")]
        public string? Company { get; set; }

        [JsonProperty("blog")]
        public string? Blog { get; set; }

        [JsonProperty("location")]
        public string? Location { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("hireable")]
        public string? Hireable { get; set; }

        [JsonProperty("bio")]
        public string? Bio { get; set; }

        [JsonProperty("twitter_username")]
        public string? TwitterUsername { get; set; }

        [JsonProperty("public_repos")]
        public int PublicRepos
        {
            get { return this._public_repos; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Reposes cannot be a negative number");
                }

                this._public_repos = value;
            }
        }

        [JsonProperty("public_gists")]
        public int PublicGists
        {
            get { return this._public_gists; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Reposes cannot be a negative number");
                }

                this._public_gists = value;
            }
        }

        [JsonProperty("followers")]
        public int Followers
        {
            get { return this._followers; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Followers cannot be a negative number");
                }

                this._followers = value;
            }
        }

        [JsonProperty("following")]
        public int Following
        {
            get { return this._following; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Following cannot be a negative number");
                }

                this._following = value;
            }
        }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime LastUpdatedAt
        {
            get { return this._updated_at; }
            private set
            {
                if (value < CreatedAt)
                {
                    throw new ArgumentOutOfRangeException(
                        "Updated at date and time cannot be before the creation of the account");
                }

                this._updated_at = value;
            }
        }

        [JsonProperty("avatar_url")]
        public string? AvatarUrl { get; set; }

    }
}
