using System.Collections.Generic;

using WebApiDemo.Models;

public static class SampleDb
{

    public static List<Branch> Branches = new List<Branch>
    {
        new Branch { BranchId = 1, BranchName = "Computer Science" },
        new Branch { BranchId = 2, BranchName = "Electrical" },
        new Branch { BranchId = 3, BranchName = "Mechanical" }
    };

    public static List<Address> Addresses = new List<Address>
    {
        new Address { AddressId = 1, Street = "Main Street 101", City = "Chennai" },
        new Address { AddressId = 2, Street = "Anna Nagar 50", City = "Chennai" },
        new Address { AddressId = 3, Street = "OMR Road 220", City = "Chennai" }
    };


    public static List<Subject> Subjects = new List<Subject>
    {
        new Subject { SubjectId = 1, SubjectName = "Maths" },
        new Subject { SubjectId = 2, SubjectName = "Physics" },
        new Subject { SubjectId = 3, SubjectName = "C Programming" }
    };


    public static List<Course> Courses = new List<Course>
    {
        new Course { CourseId = 1, CourseName = "B.Tech CS" },
        new Course { CourseId = 2, CourseName = "B.Tech IT" },
        new Course { CourseId = 3, CourseName = "B.Tech EEE" }
    };


    public static List<Teacher> Teachers = new List<Teacher>
    {
        new Teacher
        {
            TeacherId = 1,
            TeacherName = "Dr. Ravi",
            BranchId = 1,
            AddressId = 1,
            Subjects = new List<Subject>()
        },
        new Teacher
        {
            TeacherId = 2,
            TeacherName = "Dr. Meena",
            BranchId = 2,
            AddressId = 2,
            Subjects = new List<Subject>()
        }
    };


    public static List<Student> Students = new List<Student>
    {
        new Student
        {
            StudentId = 1,
            StudentName = "Suman",
            BranchId = 1,
            AddressId = 1,
            Courses = new List<Course>()
        },
        new Student
        {
            StudentId = 2,
            StudentName = "Arjun",
            BranchId = 2,
            AddressId = 2,
            Courses = new List<Course>()
        },
        new Student
        {
            StudentId = 3,
            StudentName = "Vikram",
            BranchId = 3,
            AddressId = 3,
            Courses = new List<Course>()
        }
    };
}