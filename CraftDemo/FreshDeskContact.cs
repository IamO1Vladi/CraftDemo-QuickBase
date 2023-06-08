using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CraftDemo
{
    public class FreshDeskContact
    {
        public FreshDeskContact(string name, string email, string? twitterId, int uniqueExternalId, string? address, string? description)
        {
            this.Name = name;
            this.Email = email;
            this.TwitterId = twitterId;
            this.UniqueExternalId = uniqueExternalId;
            this.Address = address;
            this.Description = description;
        }

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("twitter_id")]
        public string? TwitterId { get; set; }

        [JsonProperty("unique_external_id")]
        public int UniqueExternalId { get; set; }
        [JsonProperty("address")]
        public string? Address { get; set; }


        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("id")]
        public long  Id { get; set; }
    }
}
