using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftDemo.Database.Data.Models;
using CraftDemo.Database.DataProccessor.ImportDto;

namespace CraftDemo.Database.Data
{
    internal class CraftDemoConfig :DbContext
    {

        public CraftDemoConfig()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
        
        public DbSet<GitHubUserInfo> GitHubUserInfo { get; set; } = null!;

        
    }
}
