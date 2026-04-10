using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfCorePractice.Data;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Services;

public class BranchService : IBranchService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BranchService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResponse<BranchDTO>> GetBranchesAsync(PaginationParams pagination)
    {
        var query = _context.Branches.AsQueryable();
        var totalRecords = await query.CountAsync();

        var branches = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ProjectTo<BranchDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResponse<BranchDTO>(branches, pagination.PageNumber, pagination.PageSize, totalRecords);
    }

    public async Task<BranchDTO?> GetBranchByIdAsync(int id)
    {
        return await _context.Branches
            .Where(b => b.BranchId == id)
            .ProjectTo<BranchDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateBranchAsync(BranchCreateDTO dto)
    {
        var branch = _mapper.Map<Branch>(dto);
        _context.Branches.Add(branch);
        await _context.SaveChangesAsync();
        return branch.BranchId;
    }

    public async Task<bool> UpdateBranchAsync(int id, BranchUpdateDTO dto)
    {
        var branch = await _context.Branches.FindAsync(id);
        if (branch == null) return false;

        _mapper.Map(dto, branch);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteBranchAsync(int id)
    {
        var branch = await _context.Branches.FindAsync(id);
        if (branch == null) return false;

        _context.Branches.Remove(branch);
        await _context.SaveChangesAsync();
        return true;
    }
}
