using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfCorePractice.Data;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Services;

public class TeacherService : ITeacherService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TeacherService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResponse<TeacherDTO>> GetTeachersAsync(PaginationParams pagination)
    {
        var query = _context.Teachers
            .Include(t => t.Branch)
            .Include(t => t.Address)
            .AsQueryable();

        var totalRecords = await query.CountAsync();

        var teachers = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ProjectTo<TeacherDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResponse<TeacherDTO>(teachers, pagination.PageNumber, pagination.PageSize, totalRecords);
    }

    public async Task<TeacherDTO?> GetTeacherByIdAsync(int id)
    {
        return await _context.Teachers
            .Include(t => t.Branch)
            .Include(t => t.Address)
            .Where(t => t.TeacherId == id)
            .ProjectTo<TeacherDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateTeacherAsync(TeacherCreateDTO dto)
    {
        var teacher = _mapper.Map<Teacher>(dto);

        if (dto.SubjectIds != null && dto.SubjectIds.Any())
        {
            teacher.Subjects = await _context.Subjects
                .Where(s => dto.SubjectIds.Contains(s.SubjectId))
                .ToListAsync();
        }

        _context.Teachers.Add(teacher);
        await _context.SaveChangesAsync();
        return teacher.TeacherId;
    }

    public async Task<bool> UpdateTeacherAsync(int id, TeacherUpdateDTO dto)
    {
        var teacher = await _context.Teachers
            .Include(t => t.Subjects)
            .FirstOrDefaultAsync(t => t.TeacherId == id);

        if (teacher == null) return false;

        _mapper.Map(dto, teacher);

        teacher.Subjects.Clear();
        if (dto.SubjectIds != null && dto.SubjectIds.Any())
        {
            teacher.Subjects = await _context.Subjects
                .Where(s => dto.SubjectIds.Contains(s.SubjectId))
                .ToListAsync();
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTeacherAsync(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null) return false;

        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();
        return true;
    }
}
