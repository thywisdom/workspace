using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.Models;
public class Teacher
{
    [Key]
    public int TeacherId { get; set; }

    [Required]
    [MaxLength(80)]
    public string TeacherName { get; set; }

    [Required]
    public int BranchId { get; set; }
    public Branch Branch { get; set; }

    [Required]
    public int AddressId { get; set; }
    public Address Address { get; set; }

    public ICollection<Subject> Subjects { get; set; }
}


