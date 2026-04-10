using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.DTOs;

public class CourseDTO
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }

    public int? StudentCount { get; set; }
    public int? SubjectCount { get; set; }
}

public class CourseCreateDTO
{
    [Required]
    public string CourseName { get; set; }

    public List<int> StudentIds { get; set; }
    public List<int> SubjectIds { get; set; }
}

public class CourseUpdateDTO
{
    [Required]
    public string CourseName { get; set; }

    public List<int> StudentIds { get; set; }
    public List<int> SubjectIds { get; set; }
}
