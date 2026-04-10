using System;
using System.ComponentModel.DataAnnotations;
namespace EfCorePractice.Models;

public class Address
{

    [Key]
    public int AddressId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Street { get; set; }

    [Required]
    [MaxLength(50)]
    public string City { get; set; }

    public Student Student { get; set; }
    public Teacher Teacher { get; set; }

}
