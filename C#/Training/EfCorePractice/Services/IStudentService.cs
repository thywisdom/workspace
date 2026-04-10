using System.Threading.Tasks;
using EfCorePractice.DTOs;
using EfCorePractice.Models;

namespace EfCorePractice.Services;

public interface IStudentService
{
    Task<PagedResponse<StudentDTO>> GetStudentsAsync(PaginationParams pagination);
    Task<PagedResponse<StudentDTO>> GetStudentsByCityAsync(string city, PaginationParams pagination);
    Task<StudentDTO?> GetStudentByIdAsync(int id);
    Task<int> CreateStudentAsync(StudentCreateDTO dto);
    Task<bool> UpdateStudentAsync(int id, StudentUpdateDTO dto);
    Task<bool> DeleteStudentAsync(int id);
}
