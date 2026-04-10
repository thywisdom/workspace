using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models;

public class Course
{
    [Key]
    public int CourseId { get; set; }

    [Required, MaxLength(100)]
    public string CourseName { get; set; }

    // Many Students enroll in this course
    public ICollection<Student> Students { get; set; }

    // Many Subjects in this course
    public ICollection<Subject> Subjects { get; set; }
}
