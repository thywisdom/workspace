using System.ComponentModel.DataAnnotations;

namespace EfCorePractice.DTOs;

public class AddressDTO
{
    public int? AddressId { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
}

public class AddressCreateDTO
{
    [Required, MaxLength(100)]
    public string Street { get; set; }

    [Required, MaxLength(50)]
    public string City { get; set; }
}

public class AddressUpdateDTO
{
    [Required, MaxLength(250)]
    public string Street { get; set; }

    [Required, MaxLength(50)]
    public string City { get; set; }
}
