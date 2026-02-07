using AgroSolution.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgroSolution.Core.Infra.Data;

public class AgroIdentityDbContext : IdentityDbContext<User>
{
    public AgroIdentityDbContext(DbContextOptions<AgroIdentityDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);  
        builder.ApplyConfigurationsFromAssembly(typeof(AgroIdentityDbContext).Assembly);
    }
}