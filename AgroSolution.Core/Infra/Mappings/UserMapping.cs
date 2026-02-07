using AgroSolution.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgroSolution.Core.Infra.Mappings;

public class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.Property(u => u.FullName)
            .HasColumnName("full_name")
            .HasMaxLength(200)
            .IsRequired();
        
        builder.HasKey(u => u.Id);
        
      builder.HasIndex(u => u.NormalizedEmail).HasDatabaseName("EmailIndex").IsUnique(); 
    }
}