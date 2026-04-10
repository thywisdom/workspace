using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.DTOs;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<TeacherDTO>> GetTeachers ()
        {
            var teacherDTO = SampleDb.Teachers.Select( t => new TeacherDTO
            {
                TeacherId = t.TeacherId,
                TeacherName = t.TeacherName,
                BranchName = SampleDb.Branches.FirstOrDefault
                                (b => b.BranchId == t.BranchId)?.BranchName,
                City = SampleDb.Addresses.FirstOrDefault
                                (a => a.AddressId == t.AddressId).City,
                Subjects = t.Subjects.Select( s => s.SubjectName).ToList()
            }
            ).ToList();
            return Ok(teacherDTO);
        }

        [HttpGet("{id}")]
        public ActionResult<TeacherDTO> GetTeacherById ( int id)
        {
            var teacher = SampleDb.Teachers.FirstOrDefault( t => t.TeacherId == id);

            if( teacher == null)
            {
                return NotFound ($" Teacher with id {id} is not found.");
            }

            var teacherDTO = new TeacherDTO
            {
                TeacherId = teacher.TeacherId,
                TeacherName = teacher.TeacherName,
                BranchName = SampleDb.Branches.FirstOrDefault
                                ( b => b.BranchId == teacher.BranchId )?.BranchName,
                City = SampleDb.Addresses.FirstOrDefault
                                ( a => a.AddressId == teacher.AddressId).City,
                Subjects = teacher.Subjects.Select( s => s.SubjectName).ToList()
            };

            return Ok(teacherDTO);
        }


    }
}
