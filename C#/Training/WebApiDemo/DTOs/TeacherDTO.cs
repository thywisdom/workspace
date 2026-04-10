using System;

namespace WebApiDemo.DTOs;

public class TeacherDTO
{
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }

    public string BranchName { get; set; }
    public string City { get; set; }

    public List<string> Subjects { get; set; }
}
