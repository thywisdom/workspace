using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiDemo.Models;

namespace WebApiDemo.DTOs;

public class ProductCreateDTO
{
    public string ProductName { get; set; }


    [ForeignKey("CategoryId")]
    [Required(ErrorMessage = "Must select a category")]
    public  String CategoryName { get; set; }
    
    [Required(ErrorMessage = "Price is required")] 
    [Range(0.01, 999999.99, ErrorMessage = "Price must be greater than 0")] 
    [Column(TypeName = "decimal(8,2)")]
     public decimal Price { get; set; }

}
