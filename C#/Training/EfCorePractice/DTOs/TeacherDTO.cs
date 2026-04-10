using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.DTOs;

public class TeacherDTO
{
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }

    public string BranchName { get; set; }
    public string City { get; set; }

    public List<string> Subjects { get; set; }
}

public class TeacherDetailsDTO
{
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }

    public int BranchId { get; set; }
    public string BranchName { get; set; }

    public int AddressId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
}

public class TeacherCreateDTO
{
    [Required]
    public string TeacherName { get; set; }

    [Required]
    public int BranchId { get; set; }

    [Required]
    public int AddressId { get; set; }

    public List<int> SubjectIds { get; set; }
}

public class TeacherUpdateDTO
{
    [Required]
    public string TeacherName { get; set; }

    [Required]
    public int BranchId { get; set; }

    [Required]
    public int AddressId { get; set; }

    public List<int> SubjectIds { get; set; }
}
