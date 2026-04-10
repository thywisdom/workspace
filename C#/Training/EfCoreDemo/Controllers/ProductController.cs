using EfCoreDemo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.DTOs;
using EfCoreDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public ProductController (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await _appDbContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync( p => p.ProductId == id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> PostProduct([FromBody] ProductCreateDTO createDTO)
        {
            if(createDTO == null)
            {
                return BadRequest( new { Message = "Invalid Data"});
            }

            var newProduct = new Product
            {
                ProductName = createDTO.ProductName,
                Price = createDTO.Price,
                CategoryId = createDTO.CategoryId
            };

            await _appDbContext.Products.AddAsync(newProduct);
            await _appDbContext.SaveChangesAsync();
            
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.ProductId },createDTO);                
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductById( int id , [FromBody] ProductUpdateDTO updateDTO)
        {   
            if(id != updateDTO.ProductId )
            {
                return BadRequest(new { Message = "ID Mismatch between route and body."});
            }

            var product = await _appDbContext.Products.FindAsync(id);

             if(product == null )
            {
                return NotFound(new { Message = $"Product with id {id} is not found."});
            }

            product.ProductName = updateDTO.ProductName;
            product.Price = updateDTO.Price;
            product.CategoryId = updateDTO.CategoryId;

            _appDbContext.Entry(product).State = EntityState.Modified;

            await _appDbContext.SaveChangesAsync();

            return Ok( new { Message= "Product updated Successfully.", Product = product});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _appDbContext.Products.FindAsync(id);

            if( product == null)
            {
                return NotFound( new { Message = $"Product with {id} not found."});
            }

            _appDbContext.Products.Remove(product);
            
            await _appDbContext.SaveChangesAsync();
            return Ok( new { Message = "Product deleted Successfully"});

        }

    }
    
}
