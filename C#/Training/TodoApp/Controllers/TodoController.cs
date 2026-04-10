using Microsoft.AspNetCore.Mvc;
using ToDoApp.DTOs;
using ToDoApp.Models;
using ToDoApp.Services;
namespace ToDoApp.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoServices _todoServices;

    public TodoController ( ITodoServices todoServices)
    {
        _todoServices = todoServices;                
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams pagination)
    {
        var result = await _todoServices.GetAllAsync(pagination);

        if (result.Data.Count == 0)
            return Ok(new { message = "No Todo items found" });

        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var todo = await _todoServices.GetByIdAsync(id);
        if (todo == null)
        {
            return NotFound(new { message = $"No Todo item with Id {id} found." });
        }
        return Ok(new { message = $"Successfully retrieved Todo item with Id {id}.", data = todo });
    }
    [HttpPost]
    public async Task<IActionResult> CreateTodoAsync(CreateTodo request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _todoServices.CreateTodoAsync(request);
        return Ok(new { message = "Todo Item successfully created" });
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTodoAsync(Guid id, UpdateTodo request)
    {

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _todoServices.UpdateTodoAsync(id, request);
        return Ok(new { message = $" Todo Item  with id {id} successfully updated" });
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTodoAsync(Guid id)
    {
        await _todoServices.DeleteTodoAsync(id);
        return Ok(new { message = $"Todo  with id {id} successfully deleted" });
    }
}
