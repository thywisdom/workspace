using AutoMapper;
using ToDoApp.DTOs;
using ToDoApp.Data;
using ToDoApp.Services;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    public class TodoServices : ITodoServices
    {
        private readonly AppDbContext _context;
        private readonly ILogger<TodoServices> _logger;
        private readonly IMapper _mapper;

        public TodoServices ( AppDbContext context , ILogger<TodoServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateTodoAsync ( CreateTodo request)
        {
            try
            {
                var todo = _mapper.Map<Todo>(request);
                todo.CreatedDate = DateTime.Now;
                _context.Todos.Add(todo);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"An error occurred while creating the todo item.");
                throw;
            }
        }

        public async Task DeleteTodoAsync(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if(todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"No Todo items found {id}");
            }
        }

    public async Task<PagedResponse<Todo>> GetAllAsync(PaginationParams paginationParams)
    {
        var query = _context.Todos.AsQueryable();

        var totalRecords = await query.CountAsync();

        var items = await query
            .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
            .Take(paginationParams.PageSize)
            .ToListAsync();

        return new PagedResponse<Todo>(
            items,
            paginationParams.PageNumber,
            paginationParams.PageSize,
            totalRecords
        );
    }

        public async Task<Todo> GetByIdAsync (Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if( todo == null)
            {
                throw new KeyNotFoundException($"No Todo tem found Id {id} found.");
            }
            return todo;
        }

        public async Task UpdateTodoAsync ( Guid id, UpdateTodo request )
        {
            try
            {
                var todo = await _context.Todos.FindAsync(id);
                if (todo == null)
                {
                    throw new KeyNotFoundException($"Todo item with id {id} not found.");
                }

                 if (request.Title != null)
                {
                    todo.Title = request.Title;
                }

                if (request.Description != null)
                {
                    todo.Description = request.Description;
                }

                if (request.IsCompleted != null)
                {
                    todo.IsCompleted = request.IsCompleted.Value;
                }

                if (request.DueDate != null)
                {
                    todo.DueDate = request.DueDate.Value;
                }

                if (request.Priority != null)
                {
                    todo.Priority = request.Priority.Value;
                }

                todo.UpdatedDate = DateTime.Now;

                await _context.SaveChangesAsync();

            }
            catch ( Exception ex )
            {
                _logger.LogError(ex,$"An error occurred while updating the todo item with id {id}.");
                throw;
            }
        }

    }
}