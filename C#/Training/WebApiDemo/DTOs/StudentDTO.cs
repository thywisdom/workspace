using System;

namespace WebApiDemo.DTOs;

public class StudentDTO
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }

    public string BranchName { get; set; }
    public string City { get; set; }

    public List<string> Courses { get; set; }
}
