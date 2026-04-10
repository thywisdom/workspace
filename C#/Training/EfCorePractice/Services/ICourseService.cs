using System.Threading.Tasks;
using EfCorePractice.DTOs;
using EfCorePractice.Models;

namespace EfCorePractice.Services;

public interface ICourseService
{
    Task<PagedResponse<CourseDTO>> GetCoursesAsync(PaginationParams pagination);
    Task<CourseDTO?> GetCourseByIdAsync(int id);
    Task<int> CreateCourseAsync(CourseCreateDTO dto);
    Task<bool> UpdateCourseAsync(int id, CourseUpdateDTO dto);
    Task<bool> DeleteCourseAsync(int id);
}
