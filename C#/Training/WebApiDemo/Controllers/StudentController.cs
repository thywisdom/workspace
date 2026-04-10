using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using WebApiDemo.Models;
using WebApiDemo.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<StudentDTO>> GetStudents()
        {
            var studentDTO = SampleDb.Students.Select( s => new StudentDTO
            {
                StudentId = s.StudentId,
                StudentName = s.StudentName,
                BranchName = SampleDb.Branches.FirstOrDefault( b => b.BranchId == s.BranchId)?.BranchName,
                City = SampleDb.Addresses.FirstOrDefault( a => a.AddressId == s.AddressId).City,
                Courses = s.Courses?.Select(c => c.CourseName)?.ToList()
            }).ToList();

            return Ok(studentDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<StudentDTO> GetStudentById (int id)
        {   
            var student = SampleDb.Students.FirstOrDefault( s => s.StudentId == id );
            var studentDTO = new StudentDTO
            {
                StudentId = student.StudentId,
                StudentName = student.StudentName,
                BranchName = SampleDb.Branches.FirstOrDefault( b => b.BranchId == student.BranchId)?.BranchName,
                City = SampleDb.Addresses.FirstOrDefault( a => a.AddressId == student.AddressId).City,
                Courses = student.Courses?.Select(c => c.CourseName)?.ToList()
            };

            return Ok(studentDTO);
        }

        [HttpPost]
        public ActionResult<StudentDTO> AddStudent ([FromBody] StudentCreateDTO newStudent)
        {
            var student = new Student
            {
                StudentId = SampleDb.Students.Max( s => s.StudentId) + 1,
                StudentName = newStudent.StudentName,
                BranchId = newStudent.BranchId,
                AddressId = newStudent.AddressId,
                Courses = SampleDb.Courses.Where(c => newStudent.CourseIds.Contains(c.CourseId)).ToList()
            };

            return CreatedAtAction(nameof(GetStudentById),new { id = student.StudentId }, student);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id, StudentUpdateDTO dto)
        {
        

            return Ok($"Student with ID {id} updated successfully.");
        }



    }
}
