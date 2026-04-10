using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.Models;
public class Student
{
    [Key]
    public int StudentId { get; set; }

    [Required]
    [MaxLength(80)]
    public string StudentName { get; set; }


    [Required]
    public int BranchId { get; set; }
    public Branch Branch { get; set; }


    [Required]
    public int AddressId { get; set; }
    public Address Address { get; set; }


    public ICollection<Course>? Courses { get; set; }
}
