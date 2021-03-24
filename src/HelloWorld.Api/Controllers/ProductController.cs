using HelloWorld.Api.Models;
using HelloWorld.Data;
using HelloWorld.Data.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HelloWorld.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController(HelloWorldDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly HelloWorldDbContext _dbContext;

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _dbContext.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProduct([FromBody] CreateProductRequest request)
        {
            var product = new Product(request.Name, request.Description, request.RetailPrice);
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, new { id = product.Id });
        }
    }
}
