using AutoMapper;
using AutoMapper.QueryableExtensions;
using EfCorePractice.Data;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCorePractice.Services;

public class AddressService : IAddressService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public AddressService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResponse<AddressDTO>> GetAddressesAsync(PaginationParams pagination)
    {
        var query = _context.Addresses.AsQueryable();
        var totalRecords = await query.CountAsync();

        var addresses = await query
            .Skip((pagination.PageNumber - 1) * pagination.PageSize)
            .Take(pagination.PageSize)
            .ProjectTo<AddressDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return new PagedResponse<AddressDTO>(addresses, pagination.PageNumber, pagination.PageSize, totalRecords);
    }

    public async Task<AddressDTO?> GetAddressByIdAsync(int id)
    {
        return await _context.Addresses
            .Where(a => a.AddressId == id)
            .ProjectTo<AddressDTO>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateAddressAsync(AddressCreateDTO dto)
    {
        var address = _mapper.Map<Address>(dto);
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
        return address.AddressId;
    }

    public async Task<bool> UpdateAddressAsync(int id, AddressUpdateDTO dto)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address == null) return false;

        _mapper.Map(dto, address);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAddressAsync(int id)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address == null) return false;

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
        return true;
    }
}
