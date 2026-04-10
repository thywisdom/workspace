using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EfCorePractice.DTOs;
using EfCorePractice.Models;
using EfCorePractice.Services;

namespace EfCorePractice.Controllers;

[Authorize]
[Route("api/[controller]/[action]")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;
    public AddressController(IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpGet]
    public async Task<ActionResult<PagedResponse<AddressDTO>>> GetAddresses([FromQuery] PaginationParams pagination)
    {
        var response = await _addressService.GetAddressesAsync(pagination);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AddressDTO>> GetAddressById(int id)
    {
        var address = await _addressService.GetAddressByIdAsync(id);
        if (address == null) return NotFound(new { Message = "Address not found" });
        return Ok(address);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<ActionResult> PostAddress(AddressCreateDTO dto)
    {
        var id = await _addressService.CreateAddressAsync(dto);
        return Ok(new { Message = "Address Created", AddressId = id });
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Teacher")]
    public async Task<ActionResult> UpdateAddress(int id, AddressUpdateDTO dto)
    {
        var updated = await _addressService.UpdateAddressAsync(id, dto);
        if (!updated) return NotFound(new { Message = "Address not found" });
        return Ok(new { Message = "Address Updated" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteAddress(int id)
    {
        var deleted = await _addressService.DeleteAddressAsync(id);
        if (!deleted) return NotFound(new { Message = "Address not found" });
        return Ok(new { Message = "Address Deleted" });
    }
}