using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using EfCorePractice.Services;

namespace EfCorePractice.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeacherController(ITeacherService teacherService)
    {
        _teacherService = teacherService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<TeacherDTO>>> GetTeachers([FromQuery] PaginationParams pagination)
    {
        var response = await _teacherService.GetTeachersAsync(pagination);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherDTO>> GetTeacherById(int id)
    {
        var teacher = await _teacherService.GetTeacherByIdAsync(id);
        if (teacher == null) return NotFound(new { Message = "Teacher not found" });
        return Ok(teacher);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> PostTeacher(TeacherCreateDTO dto)
    {
        var id = await _teacherService.CreateTeacherAsync(dto);
        return Ok(new { Message = "Teacher Created", TeacherId = id });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateTeacher(int id, TeacherUpdateDTO dto)
    {
        var updated = await _teacherService.UpdateTeacherAsync(id, dto);
        if (!updated) return NotFound(new { Message = "Teacher not found" });
        return Ok(new { Message = "Teacher Updated" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteTeacher(int id)
    {
        var deleted = await _teacherService.DeleteTeacherAsync(id);
        if (!deleted) return NotFound(new { Message = "Teacher not found" });
        return Ok(new { Message = "Teacher Deleted" });
    }
}