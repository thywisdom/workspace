using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiDemo.DTOs;

public class StudentCreateDTO
{
    [Required, MaxLength(80)]
    public string StudentName { get; set; }

    [Required]
    public int BranchId { get; set; }

    [Required]
    public int AddressId { get; set; }

    public List<int> CourseIds { get; set; }
}
