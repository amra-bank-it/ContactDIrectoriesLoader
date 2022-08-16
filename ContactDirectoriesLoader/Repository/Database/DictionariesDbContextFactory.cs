using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDirectoriesLoader.Repository.Database
{
    public class DictionariesDbContextFactory : IDesignTimeDbContextFactory<DictionariesDbContext>
    {
        public DictionariesDbContext CreateDbContext(string[] args)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                .AddJsonFile("appsettings.json")
                                                .Build();
            var connectionString = Configuration["ConnectionStrings:DictionariesConnectionString"];

            var optionsBuilder = new DbContextOptionsBuilder<DictionariesDbContext>();

            optionsBuilder.UseSqlServer(connectionString, providerOptions =>
            {
                providerOptions.CommandTimeout(300);
                providerOptions.EnableRetryOnFailure(5, TimeSpan.FromMilliseconds(500), null);
            });

            return new DictionariesDbContext(optionsBuilder.Options);
        }
    }
}
