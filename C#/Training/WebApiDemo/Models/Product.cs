using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiDemo.Models;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Must Mention Product Name")]
    [MaxLength(100)]
    public required string ProductName { get; set; }

    [Required]
    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    [Required(ErrorMessage = "Must select a category")]
    public  Category Category { get; set; }
    
    [Required(ErrorMessage = "Price is required")] 
    [Range(0.01, 999999.99, ErrorMessage = "Price must be greater than 0")] 
    [Column(TypeName = "decimal(8,2)")]
     public decimal Price { get; set; }

    [Required] 
    public bool IsActive { get; set; } = true;

}
