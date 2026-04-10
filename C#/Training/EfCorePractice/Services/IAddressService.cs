using System.Threading.Tasks;
using EfCorePractice.DTOs;
using EfCorePractice.Models;

namespace EfCorePractice.Services;

public interface IAddressService
{
    Task<PagedResponse<AddressDTO>> GetAddressesAsync(PaginationParams pagination);
    Task<AddressDTO?> GetAddressByIdAsync(int id);
    Task<int> CreateAddressAsync(AddressCreateDTO dto);
    Task<bool> UpdateAddressAsync(int id, AddressUpdateDTO dto);
    Task<bool> DeleteAddressAsync(int id);
}
