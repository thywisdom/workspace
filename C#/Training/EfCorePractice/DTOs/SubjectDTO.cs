using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.DTOs;

public class SubjectDTO
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public int TeacherCount { get; set; }
    public int CourseCount { get; set; }
}

public class SubjectCreateDTO
{
    [Required]
    public string SubjectName { get; set; }

    public List<int> TeacherIds { get; set; }
    public List<int> CourseIds { get; set; }
}

public class SubjectUpdateDTO
{
    [Required]
    public string SubjectName { get; set; }

    public List<int> TeacherIds { get; set; }
    public List<int> CourseIds { get; set; }
}
