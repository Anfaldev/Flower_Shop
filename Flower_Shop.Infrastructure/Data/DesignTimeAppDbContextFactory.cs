using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Flower_Shop.Infrastructure.Data
{
    public sealed class DesignTimeAppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable(
                "ConnectionStrings__DefaultDatabase");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                var currentDirectory = Directory.GetCurrentDirectory();
                var configPath = Path.Combine(currentDirectory, "appsettings.json");

                if (!File.Exists(configPath))
                {
                    configPath = Path.Combine(
                        currentDirectory,
                        "Flower_Shop",
                        "appsettings.json");
                }

                using var config = JsonDocument.Parse(File.ReadAllText(configPath));
                connectionString = config.RootElement
                    .GetProperty("ConnectionStrings")
                    .GetProperty("DefaultDatabase")
                    .GetString();
            }

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new InvalidOperationException("The DefaultDatabase connection string is missing.");

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new AppDbContext(options);
        }
    }
}
