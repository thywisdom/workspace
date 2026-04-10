using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using EfCorePractice.Services;

namespace EfCorePractice.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<CourseDTO>>> GetCourses([FromQuery] PaginationParams pagination)
    {
        var response = await _courseService.GetCoursesAsync(pagination);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseDTO>> GetCourseById(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null) return NotFound(new { Message = "Course not found" });
        return Ok(course);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<ActionResult> PostCourse(CourseCreateDTO dto)
    {
        var id = await _courseService.CreateCourseAsync(dto);
        return Ok(new { Message = "Course Created", CourseId = id });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<ActionResult> UpdateCourse(int id, CourseUpdateDTO dto)
    {
        var updated = await _courseService.UpdateCourseAsync(id, dto);
        if (!updated) return NotFound(new { Message = "Course not found" });
        return Ok(new { Message = "Course Updated" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteCourse(int id)
    {
        var deleted = await _courseService.DeleteCourseAsync(id);
        if (!deleted) return NotFound(new { Message = "Course not found" });
        return Ok(new { Message = "Course Deleted" });
    }
}