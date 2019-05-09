using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryEntity
{
    public class dbContext:DbContext
    {
        public dbContext(DbContextOptions options) : base(options) { }
        public DbSet<Files> AllFiles { get; set; }

        public dbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            string connetionString = configuration["ConnectionStrings:Default"];
            optionsBuilder.UseSqlServer(connetionString);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
