using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfCorePractice.Data;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Services;

public class CourseService : ICourseService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CourseService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResponse<CourseDTO>> GetCoursesAsync(PaginationParams pagination)
    {
        var query = _context.Courses
            .Include(c => c.Students)
            .Include(c => c.Subjects)
            .AsQueryable();

        var totalRecords = await query.CountAsync();

        var courses = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ProjectTo<CourseDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResponse<CourseDTO>(courses, pagination.PageNumber, pagination.PageSize, totalRecords);
    }

    public async Task<CourseDTO?> GetCourseByIdAsync(int id)
    {
        return await _context.Courses
            .Include(c => c.Students)
            .Include(c => c.Subjects)
            .Where(c => c.CourseId == id)
            .ProjectTo<CourseDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateCourseAsync(CourseCreateDTO dto)
    {
        var course = _mapper.Map<Course>(dto);

        if (dto.StudentIds != null && dto.StudentIds.Any())
        {
            course.Students = await _context.Students
                .Where(s => dto.StudentIds.Contains(s.StudentId))
                .ToListAsync();
        }

        if (dto.SubjectIds != null && dto.SubjectIds.Any())
        {
            course.Subjects = await _context.Subjects
                .Where(s => dto.SubjectIds.Contains(s.SubjectId))
                .ToListAsync();
        }

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();
        return course.CourseId;
    }

    public async Task<bool> UpdateCourseAsync(int id, CourseUpdateDTO dto)
    {
        var course = await _context.Courses
            .Include(c => c.Students)
            .Include(c => c.Subjects)
            .FirstOrDefaultAsync(c => c.CourseId == id);

        if (course == null) return false;

        _mapper.Map(dto, course);

        course.Students.Clear();
        if (dto.StudentIds != null && dto.StudentIds.Any())
        {
            course.Students = await _context.Students
                .Where(s => dto.StudentIds.Contains(s.StudentId))
                .ToListAsync();
        }

        course.Subjects.Clear();
        if (dto.SubjectIds != null && dto.SubjectIds.Any())
        {
            course.Subjects = await _context.Subjects
                .Where(s => dto.SubjectIds.Contains(s.SubjectId))
                .ToListAsync();
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteCourseAsync(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course == null) return false;

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return true;
    }
}
