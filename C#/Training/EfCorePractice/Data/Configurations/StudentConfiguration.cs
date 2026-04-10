using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCorePractice.Data.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Students");
        builder.HasKey(s => s.StudentId);

        builder.HasOne(s => s.Branch)
               .WithMany(b => b.Students)
               .HasForeignKey(s => s.BranchId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Address)
               .WithOne(a => a.Student)
               .HasForeignKey<Student>(s => s.AddressId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.Courses)
               .WithMany(c => c.Students)
               .UsingEntity(j => j.ToTable("StudentCourses"));
    }
}
