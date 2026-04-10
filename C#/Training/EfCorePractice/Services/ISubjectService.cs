using System.Threading.Tasks;
using EfCorePractice.DTOs;
using EfCorePractice.Models;

namespace EfCorePractice.Services;

public interface ISubjectService
{
    Task<PagedResponse<SubjectDTO>> GetSubjectsAsync(PaginationParams pagination);
    Task<SubjectDTO?> GetSubjectByIdAsync(int id);
    Task<int> CreateSubjectAsync(SubjectCreateDTO dto);
    Task<bool> UpdateSubjectAsync(int id, SubjectUpdateDTO dto);
    Task<bool> DeleteSubjectAsync(int id);
}
