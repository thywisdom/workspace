using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCorePractice.Data.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        builder.HasKey(c => c.CourseId);

        builder.Property(c => c.CourseName)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasMany(c => c.Subjects)
               .WithMany(s => s.Courses)
               .UsingEntity(j => j.ToTable("CourseSubjects"));
    }
}
