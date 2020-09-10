using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RosabellaCosmetics.Dal.DbContext;
using RosabellaCosmetics.Dal.Settings;
using System.IO;

namespace RosabellaCosmetics.WebUI.Utils
{
    public class RosabellaCosmeticsDbContextFactory : IDesignTimeDbContextFactory<RosabellaCosmeticsDbContext>
    {
        public RosabellaCosmeticsDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var builder = new DbContextOptionsBuilder<RosabellaCosmeticsDbContext>();
            builder.UseSqlServer(AppSettings.ConnectionString);
            return new RosabellaCosmeticsDbContext(builder.Options);
        }
    }
}
