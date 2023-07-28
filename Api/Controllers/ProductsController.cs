using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Read(int id)
        {
            return Ok();
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product product)
        {
            try
            {
                return Ok();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return Ok();
        }
    }
}
