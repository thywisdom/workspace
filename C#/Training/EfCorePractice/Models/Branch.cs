using System;
using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.Models;

public class Branch
{
    [Key]
    public int BranchId { get; set; }

    [Required]
    [MaxLength(100)]
    public string BranchName { get; set; }

    public ICollection<Student> Students { get; set; }
    public ICollection<Teacher> Teachers { get; set; }
}
