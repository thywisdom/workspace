using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.DTOs;

public class BranchDTO
{
    public int BranchId { get; set; }
    public string BranchName { get; set; }
}

public class BranchCreateDTO
{
    [Required]
    public string BranchName { get; set; }
}

public class BranchUpdateDTO
{
    [Required]
    public string BranchName { get; set; }
}
