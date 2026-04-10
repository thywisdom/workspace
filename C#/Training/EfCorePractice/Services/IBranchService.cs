using System.Threading.Tasks;
using EfCorePractice.DTOs;
using EfCorePractice.Models;

namespace EfCorePractice.Services;

public interface IBranchService
{
    Task<PagedResponse<BranchDTO>> GetBranchesAsync(PaginationParams pagination);
    Task<BranchDTO?> GetBranchByIdAsync(int id);
    Task<int> CreateBranchAsync(BranchCreateDTO dto);
    Task<bool> UpdateBranchAsync(int id, BranchUpdateDTO dto);
    Task<bool> DeleteBranchAsync(int id);
}
