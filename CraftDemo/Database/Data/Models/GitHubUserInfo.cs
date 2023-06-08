using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftDemo.Database.DataProccessor.ImportDto;
using Microsoft.EntityFrameworkCore;

namespace CraftDemo.Database.Data.Models
{
    internal class GitHubUserInfo
    {
        public GitHubUserInfo()
        {
            
        }

        [Required]
        [MaxLength(39)]
        [Unicode(false)]
        public string UserName { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(63)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }


        //I created this method so i can use a DTO for the insertion of records. Manually mapping the values for now as I am still learning about the Auto-Mapper
        public static GitHubUserInfo FromDto(ImportGitHubUserDto dto)
        {
            var user = new GitHubUserInfo()
            {
                UserName = dto.UserName,
                Id = dto.Id,
                Name = dto.Name,
                CreatedDate = dto.CreatedDate
            };

            return user;
        }

    }
}
