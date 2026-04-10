using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCorePractice.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");
        builder.HasKey(a => a.AddressId);

        builder.Property(a => a.Street)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(a => a.City)
               .HasMaxLength(50)
               .IsRequired();
    }
}
