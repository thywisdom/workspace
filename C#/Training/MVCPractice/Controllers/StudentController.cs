using Microsoft.AspNetCore.Mvc;
using mvc_eg.Models;
namespace mvc_eg.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository  _studentRepository;

        public StudentController ( IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public JsonResult GetStudentDetails(int id) {
            Student student = _studentRepository.getStudentById(id);
            return Json(student);
        }
    }
}
