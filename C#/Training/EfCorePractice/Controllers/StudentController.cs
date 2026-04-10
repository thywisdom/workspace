using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using EfCorePractice.Services;

namespace EfCorePractice.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<StudentDTO>>> GetStudents([FromQuery] PaginationParams pagination)
    {
        var response = await _studentService.GetStudentsAsync(pagination);
        return Ok(response);
    }

    [HttpGet("by-city")]
    public async Task<ActionResult<PagedResponse<StudentDTO>>> GetStudentsByCity([FromQuery] string city, [FromQuery] PaginationParams pagination)
    {
        if (string.IsNullOrWhiteSpace(city)) return BadRequest(new { message = "City parameter is required" });
        var response = await _studentService.GetStudentsByCityAsync(city, pagination);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDTO>> GetStudentById(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        if (student == null) return NotFound(new { Message = "Student not found" });
        return Ok(student);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<ActionResult> PostStudent(StudentCreateDTO dto)
    {
        var id = await _studentService.CreateStudentAsync(dto);
        return Ok(new { Message = "Student Created", StudentId = id });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<ActionResult> UpdateStudent(int id, StudentUpdateDTO dto)
    {
        var updated = await _studentService.UpdateStudentAsync(id, dto);
        if (!updated) return NotFound(new { Message = "Student not found" });
        return Ok(new { Message = "Student Updated" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteStudent(int id)
    {
        var deleted = await _studentService.DeleteStudentAsync(id);
        if (!deleted) return NotFound(new { Message = "Student not found" });
        return Ok(new { Message = "Student Deleted" });
    }
}