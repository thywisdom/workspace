using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.DTOs;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Category> _categories = new List<Category>
        {
            new Category { CategoryId = 1, CategoryName = "Electronics" },
            new Category { CategoryId = 2, CategoryName = "Clothing" },
            new Category { CategoryId = 3, CategoryName = "Groceries" }
        };

        private static List<Product> _products = new List<Product>
        {
           new Product {
                ProductId = 1,
                ProductName = "Laptop",
                CategoryId = 1,
                Price = 55000.50m,
                IsActive = true,
                Category = _categories.First( c => c.CategoryId == 1 )
            },
             new Product {
                ProductId = 2,
                ProductName = "T-Shirt",
                CategoryId = 2,
                Price = 499.99m,
                IsActive = true,
                Category = _categories.First(c => c.CategoryId == 2)
            },

            new Product {
                ProductId = 3,
                ProductName = "Rice Bag 25KG",
                CategoryId = 3,
                Price = 1200.00m,
                IsActive = true,
                Category = _categories.First(c => c.CategoryId == 3)
            }
        };

        static ProductController()
        {
            foreach ( var category in _categories)
            {
                category.Products = _products.Where(p => p.CategoryId == category.CategoryId).ToList();
            }

            foreach ( var product in _products)
            {
                product.Category = _categories.First( c => c.CategoryId == product.CategoryId);
            }
        }



        [HttpGet]
        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var ProductDTOs = _products.Select( p => new ProductDTO
            {
                ProductName = p.ProductName,
                Price = p.Price,
                CategoryName = _categories.FirstOrDefault(c => c.CategoryId == p.CategoryId)?.CategoryName ?? "Unknown" ,
                Status = p.IsActive ? "Available" : "Not Available"
            }).ToList();

            return Ok(ProductDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDTO> GetProductByID(int id)
        {
            var productDTO = _products.Where( p => p.ProductId == id ).Select( p => new ProductDTO
            {
                ProductName = p.ProductName,
                Price = p.Price,
                CategoryName = _categories.FirstOrDefault(c => c.CategoryId == p.CategoryId)?.CategoryName ?? "Unknown" ,
                Status = p.IsActive ? "Available" : "Not Available"
            }).First();

            if (productDTO == null) return NotFound("The Product Not Found");

            return Ok(productDTO);
        }

        [HttpPost]
        public ActionResult<ProductDTO> PostProduct([FromBody] ProductCreateDTO createDTO)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryName == createDTO.CategoryName);

            if (category == null)
            return BadRequest("Invalid category name");

            var newProduct =  new Product
            {
                ProductId = _products.Max( p => p.ProductId) + 1,
                ProductName = createDTO.ProductName,
                CategoryId = category.CategoryId,
                Category = category,
                Price = createDTO.Price               
                
            };

            _products.Add(newProduct);

            var productDTO  = new ProductDTO{
                
            ProductName = newProduct.ProductName,
            Price = newProduct.Price,
            CategoryName = _categories.FirstOrDefault(c => c.CategoryId == newProduct.CategoryId)?.CategoryName ?? "Unknown" ,
            Status = newProduct.IsActive ? "Available" : "Not Available"
            };

            return CreatedAtAction(nameof(GetProductByID), new { id = newProduct.ProductId },productDTO);                
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct ( int id , [FromBody] ProductUpdateDTO updateDTO)
        {
            if(id != updateDTO.ProductId )
            {
                return BadRequest(new { Message = "ID Mismatch between route and body."});
            }

            var existingProduct = _products.FirstOrDefault(p => p.ProductId == id);

            var category = _categories.FirstOrDefault( c => c.CategoryId == updateDTO.CategoryId);
            if(category == null )
            {
                return BadRequest( new { Message = "Invalis CategoryId"});
            }


            if(existingProduct == null)
            {
                return NotFound( new { Message = $"Product with {id} not found."});
            }
            
            existingProduct.ProductName = updateDTO.ProductName;
            existingProduct.Price = updateDTO.Price;
            existingProduct.CategoryId = updateDTO.CategoryId;
            existingProduct.Category = category;
            existingProduct.IsActive = updateDTO.IsActive;


            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.ProductId == id);

            if( product == null)
            {
                return NotFound( new { Message = $"Product with {id} not found."});
            }

            _products.Remove(product);

            return NoContent();

        }


    }
    
}
