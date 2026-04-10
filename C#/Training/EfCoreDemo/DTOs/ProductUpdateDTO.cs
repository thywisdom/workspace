using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EfCoreDemo.Models;

namespace WebApiDemo.DTOs;

public class ProductUpdateDTO
{
    [Key]
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Must Mention Product Name")]
    [MaxLength(100)]
    public string ProductName { get; set; }

    [ForeignKey("CategoryId")]
    [Required(ErrorMessage = "Must enter a category id")]
    public  int CategoryId { get; set; }
    
    [Required(ErrorMessage = "Price is required")] 
    [Range(0.01, 999999.99, ErrorMessage = "Price must be greater than 0")] 
    [Column(TypeName = "decimal(8,2)")]
     public decimal Price { get; set; }

    [Required] 
    public bool IsActive { get; set; } = true;
}
