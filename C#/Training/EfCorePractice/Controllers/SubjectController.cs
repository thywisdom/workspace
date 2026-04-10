using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using EfCorePractice.Services;

namespace EfCorePractice.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class SubjectController : ControllerBase
{
    private readonly ISubjectService _subjectService;

    public SubjectController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<SubjectDTO>>> GetSubjects([FromQuery] PaginationParams pagination)
    {
        var response = await _subjectService.GetSubjectsAsync(pagination);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubjectDTO>> GetSubjectById(int id)
    {
        var subject = await _subjectService.GetSubjectByIdAsync(id);
        if (subject == null) return NotFound(new { Message = "Subject not found" });
        return Ok(subject);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<ActionResult> PostSubject(SubjectCreateDTO dto)
    {
        var id = await _subjectService.CreateSubjectAsync(dto);
        return Ok(new { Message = "Subject Created", SubjectId = id });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<ActionResult> UpdateSubject(int id, SubjectUpdateDTO dto)
    {
        var updated = await _subjectService.UpdateSubjectAsync(id, dto);
        if (!updated) return NotFound(new { Message = "Subject not found" });
        return Ok(new { Message = "Subject Updated" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteSubject(int id)
    {
        var deleted = await _subjectService.DeleteSubjectAsync(id);
        if (!deleted) return NotFound(new { Message = "Subject not found" });
        return Ok(new { Message = "Subject Deleted" });
    }
}