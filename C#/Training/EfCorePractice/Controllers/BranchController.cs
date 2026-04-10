using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using EfCorePractice.Services;

namespace EfCorePractice.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class BranchController : ControllerBase
{
    private readonly IBranchService _branchService;

    public BranchController(IBranchService branchService)
    {
        _branchService = branchService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<BranchDTO>>> GetBranches([FromQuery] PaginationParams pagination)
    {
        var response = await _branchService.GetBranchesAsync(pagination);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BranchDTO>> GetBranchById(int id)
    {
        var branch = await _branchService.GetBranchByIdAsync(id);
        if (branch == null) return NotFound(new { Message = "Branch not found" });
        return Ok(branch);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> PostBranch(BranchCreateDTO dto)
    {
        var id = await _branchService.CreateBranchAsync(dto);
        return Ok(new { Message = "Branch Created", BranchId = id });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> UpdateBranch(int id, BranchUpdateDTO dto)
    {
        var updated = await _branchService.UpdateBranchAsync(id, dto);
        if (!updated) return NotFound(new { Message = "Branch not found" });
        return Ok(new { Message = "Branch Updated" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteBranch(int id)
    {
        var deleted = await _branchService.DeleteBranchAsync(id);
        if (!deleted) return NotFound(new { Message = "Branch not found" });
        return Ok(new { Message = "Branch Deleted" });
    }
}