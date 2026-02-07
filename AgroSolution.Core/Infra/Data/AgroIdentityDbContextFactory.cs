using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AgroSolution.Core.Infra.Data;

public class AgroIdentityDbContextFactory : IDesignTimeDbContextFactory<AgroIdentityDbContext>
{
    public AgroIdentityDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<AgroIdentityDbContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));

        return new AgroIdentityDbContext(optionsBuilder.Options);
    }
}