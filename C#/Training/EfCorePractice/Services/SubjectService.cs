using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfCorePractice.Data;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Services;

public class SubjectService : ISubjectService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public SubjectService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResponse<SubjectDTO>> GetSubjectsAsync(PaginationParams pagination)
    {
        var query = _context.Subjects
            .Include(s => s.Teachers)
            .Include(s => s.Courses)
            .AsQueryable();

        var totalRecords = await query.CountAsync();

        var subjects = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ProjectTo<SubjectDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResponse<SubjectDTO>(subjects, pagination.PageNumber, pagination.PageSize, totalRecords);
    }

    public async Task<SubjectDTO?> GetSubjectByIdAsync(int id)
    {
        return await _context.Subjects
            .Include(s => s.Teachers)
            .Include(s => s.Courses)
            .Where(s => s.SubjectId == id)
            .ProjectTo<SubjectDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateSubjectAsync(SubjectCreateDTO dto)
    {
        var subject = _mapper.Map<Subject>(dto);

        if (dto.TeacherIds != null && dto.TeacherIds.Any())
        {
            subject.Teachers = await _context.Teachers
                .Where(t => dto.TeacherIds.Contains(t.TeacherId))
                .ToListAsync();
        }

        if (dto.CourseIds != null && dto.CourseIds.Any())
        {
            subject.Courses = await _context.Courses
                .Where(c => dto.CourseIds.Contains(c.CourseId))
                .ToListAsync();
        }

        _context.Subjects.Add(subject);
        await _context.SaveChangesAsync();
        return subject.SubjectId;
    }

    public async Task<bool> UpdateSubjectAsync(int id, SubjectUpdateDTO dto)
    {
        var subject = await _context.Subjects
            .Include(s => s.Teachers)
            .Include(s => s.Courses)
            .FirstOrDefaultAsync(s => s.SubjectId == id);

        if (subject == null) return false;

        _mapper.Map(dto, subject);

        subject.Teachers.Clear();
        if (dto.TeacherIds != null && dto.TeacherIds.Any())
        {
            subject.Teachers = await _context.Teachers
                .Where(t => dto.TeacherIds.Contains(t.TeacherId))
                .ToListAsync();
        }

        subject.Courses.Clear();
        if (dto.CourseIds != null && dto.CourseIds.Any())
        {
            subject.Courses = await _context.Courses
                .Where(c => dto.CourseIds.Contains(c.CourseId))
                .ToListAsync();
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteSubjectAsync(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null) return false;

        _context.Subjects.Remove(subject);
        await _context.SaveChangesAsync();
        return true;
    }
}
