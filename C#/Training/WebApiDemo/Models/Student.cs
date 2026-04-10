using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.Models;
public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(80)]
    public string StudentName { get; set; }

    // FK: Branch
    [Required]
    public int BranchId { get; set; }
    public Branch Branch { get; set; }

    // FK: Address
    [Required]
    public int AddressId { get; set; }
    public Address Address { get; set; }

    // Many-to-Many: Courses
    public ICollection<Course> Courses { get; set; }
}
