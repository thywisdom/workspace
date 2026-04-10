using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models;

public class Subject
{
    [Key]
    public int SubjectId { get; set; }

    [Required, MaxLength(100)]
    public string SubjectName { get; set; }


    public ICollection<Teacher> Teachers { get; set; }


    public ICollection<Course> Courses { get; set; }
}
