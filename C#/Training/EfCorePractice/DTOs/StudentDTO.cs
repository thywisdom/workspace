using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.DTOs;

public class StudentDTO
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }

    public string BranchName { get; set; }
    public string City { get; set; }
}

public class StudentDetailsDTO
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }

    public int BranchId { get; set; }
    public string BranchName { get; set; }

    public int AddressId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
}

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

public class StudentUpdateDTO
{
    [Required, MaxLength(80)]
    public string StudentName { get; set; }

    [Required]
    public int BranchId { get; set; }

    [Required]
    public int AddressId { get; set; }
 
    public List<int> CourseIds { get; set; }
}
