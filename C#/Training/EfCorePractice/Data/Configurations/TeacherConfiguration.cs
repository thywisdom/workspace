using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCorePractice.Data.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");
        builder.HasKey(t => t.TeacherId);

        builder.HasOne(t => t.Branch)
               .WithMany(b => b.Teachers)
               .HasForeignKey(t => t.BranchId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(t => t.Address)
               .WithOne(a => a.Teacher)
               .HasForeignKey<Teacher>(t => t.AddressId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Subjects)
               .WithMany(s => s.Teachers)
               .UsingEntity(j => j.ToTable("TeacherSubjects"));
    }
}
