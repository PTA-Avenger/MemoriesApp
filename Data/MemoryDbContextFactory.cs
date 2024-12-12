using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MemoriesApp.Data
{
    public class MemoryDbContextFactory : IDesignTimeDbContextFactory<MemoryDbContext>
    {
        public MemoryDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<MemoryDbContext>();
            var connectionString = configuration.GetConnectionString("MemoryDatabase");
            optionsBuilder.UseSqlServer(connectionString);

            return new MemoryDbContext(optionsBuilder.Options);
        }
    }
}
