using System;
using System.ComponentModel.DataAnnotations;

namespace EfCoreDemo.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Required(ErrorMessage = "Customer name is required")]
    [MaxLength(100)]
    public string CustomerName { get; set; }

    [Required]
    public bool IsPaid { get; set; } = false;

    // Navigation property for many-to-many via OrderItem
    public ICollection<OrderItem> OrderItems { get; set; }

}
