using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsController(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ReadAll()
        {
            return Ok(_dbContext.Products.Where(p => !p.IsDeleted));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Read(Guid id)
        {
            var product = _dbContext.Products.Find(id);

            return product == null ? NotFound($"Product ${id} not found") : Ok(product);
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            product.CreatedAt = DateTime.Now;

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Product product)
        {
            try
            {
                product.Id = id;
                product.LastUpdatedAt = DateTime.Now;

                _dbContext.Products.Update(product);
                _dbContext.SaveChanges();

                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                var product = _dbContext.Products.Find(id);

                if(product == null)
                {
                    return NotFound($"Product {id} not found");
                }

                // hard delete
                // _dbContext.Remove(product);

                // soft delete
                product.IsDeleted = true;
                product.DeletedAt = DateTime.Now;

                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
