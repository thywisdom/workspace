using System.Threading.Tasks;
using EfCorePractice.DTOs;
using EfCorePractice.Models;

namespace EfCorePractice.Services;

public interface ITeacherService
{
    Task<PagedResponse<TeacherDTO>> GetTeachersAsync(PaginationParams pagination);
    Task<TeacherDTO?> GetTeacherByIdAsync(int id);
    Task<int> CreateTeacherAsync(TeacherCreateDTO dto);
    Task<bool> UpdateTeacherAsync(int id, TeacherUpdateDTO dto);
    Task<bool> DeleteTeacherAsync(int id);
}
