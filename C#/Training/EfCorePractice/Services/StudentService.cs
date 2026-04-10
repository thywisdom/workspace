using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfCorePractice.Data;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Services;

public class StudentService : IStudentService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public StudentService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResponse<StudentDTO>> GetStudentsAsync(PaginationParams pagination)
    {
        var query = _context.Students
            .Include(s => s.Branch)
            .Include(s => s.Address)
            .AsQueryable();

        var totalRecords = await query.CountAsync();

        var students = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ProjectTo<StudentDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResponse<StudentDTO>(students, pagination.PageNumber, pagination.PageSize, totalRecords);
    }

    public async Task<PagedResponse<StudentDTO>> GetStudentsByCityAsync(string city, PaginationParams pagination)
    {
        var query = _context.Students
            .Include(s => s.Branch)
            .Include(s => s.Address)
            .Where(s => s.Address.City.ToLower().Contains(city.ToLower()))
            .AsQueryable();

        var totalRecords = await query.CountAsync();

        var students = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ProjectTo<StudentDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResponse<StudentDTO>(students, pagination.PageNumber, pagination.PageSize, totalRecords);
    }


    public async Task<StudentDTO?> GetStudentByIdAsync(int id)
    {
        return await _context.Students
            .Include(s => s.Branch)
            .Include(s => s.Address)
            .Where(s => s.StudentId == id)
            .ProjectTo<StudentDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateStudentAsync(StudentCreateDTO dto)
    {
        var student = _mapper.Map<Student>(dto);

        if (dto.CourseIds != null && dto.CourseIds.Any())
        {
            student.Courses = await _context.Courses
                .Where(c => dto.CourseIds.Contains(c.CourseId))
                .ToListAsync();
        }

        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return student.StudentId;
    }

    public async Task<bool> UpdateStudentAsync(int id, StudentUpdateDTO dto)
    {
        var student = await _context.Students
            .Include(s => s.Courses)
            .FirstOrDefaultAsync(s => s.StudentId == id);

        if (student == null) return false;

        _mapper.Map(dto, student);

        student.Courses?.Clear();
        if (dto.CourseIds != null && dto.CourseIds.Any())
        {
            var selectedCourses = await _context.Courses
                .Where(c => dto.CourseIds.Contains(c.CourseId))
                .ToListAsync();

            student.Courses = selectedCourses;
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await _context.Students.FindAsync(id);
        if (student == null) return false;

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();
        return true;
    }
}
