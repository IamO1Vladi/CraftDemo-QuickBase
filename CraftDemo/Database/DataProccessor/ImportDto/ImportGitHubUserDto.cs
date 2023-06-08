using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CraftDemo.Database.DataProccessor.ImportDto
{
    internal class ImportGitHubUserDto
    {

        
        [Required]
        [MaxLength(39)]
        [MinLength(3)]
        [Unicode(false)]
        [JsonProperty("login")]
        public string UserName { get; set; }

        [Key]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(63)]
        [MinLength(3)]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("created_at")]
        public DateTime CreatedDate { get; set; }

    }
}
