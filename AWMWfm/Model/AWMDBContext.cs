using AWM.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AWMWfm.Model
{
    public class AWMDBContext: DbContext
    {
        public AWMDBContext()
        {

        }
        public AWMDBContext(DbContextOptions<AWMDBContext> options)
             : base(options)
        {
        }
        public DbSet<Query> Query { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<QueryType> QueryType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PlatformSettings> PlatformSettings { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("AWMDBConnectionString");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
