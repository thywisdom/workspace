using AutoMapper;
using ToDoApp.Data;
using ToDoApp.Models;
using Microsoft.EntityFrameworkCore;
namespace ToDoApp.Services;

public class UserRepository : IUserRepository
{   
    private readonly AppDbContext  _context;
    private readonly ILogger<UserRepository> _logger;
    private readonly IMapper _mapper;
    public UserRepository ( AppDbContext context, ILogger<UserRepository> logger, IMapper mapper)
    {
        _context = context;
        _logger = logger;
        _mapper = mapper;
    }
 
public async Task<User?> ValidateUser(string username, string password)
{
    return await _context.Users
        .Include(u => u.Roles)
        .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
}

public async Task<List<User>> GetAllUsers()
{
    return await _context.Users
        .Include(u => u.Roles)
        .ToListAsync();
}

public async Task<User?> GetUserById(int id)
{
    return await _context.Users
        .Include(u => u.Roles)
        .FirstOrDefaultAsync(u => u.Id == id);
}

public async Task<User> AddUser(User user)
{
    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    return user;
}

public async Task<User> UpdateUser(User user)
{
    var existingUser = await GetUserById(user.Id);

    if (existingUser == null)
        throw new KeyNotFoundException("User not found.");

    existingUser.Username = user.Username;
    existingUser.Password = user.Password;

    await _context.SaveChangesAsync();
    return existingUser;
}

public async Task DeleteUser(int id)
{
    var user = await GetUserById(id);

    if (user == null)
        throw new KeyNotFoundException("User not found.");

    _context.Users.Remove(user);
    await _context.SaveChangesAsync();
    }
}