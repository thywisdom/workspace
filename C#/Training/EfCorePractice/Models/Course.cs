using System;
using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.Models;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    [Required, MaxLength(100)]
    public string CourseName { get; set; }

    public ICollection<Student> Students { get; set; }

    public ICollection<Subject> Subjects { get; set; }
}
