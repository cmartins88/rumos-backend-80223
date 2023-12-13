using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectoFinal.Data;
using ProjectoFinal.Models;

namespace ProjectoFinal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ingredients
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
        {
          if (_context.Ingredients == null)
          {
              return NotFound();
          }
            return await _context.Ingredients.ToListAsync();
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Ingredient>> GetIngredient(Guid id)
        {
          if (_context.Ingredients == null)
          {
              return NotFound();
          }
            var ingredient = await _context.Ingredients.FindAsync(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return ingredient;
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(Guid id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            _context.Entry(ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
        {
          if (_context.Ingredients == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Ingredients'  is null.");
          }
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngredient", new { id = ingredient.Id }, ingredient);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(Guid id)
        {
            if (_context.Ingredients == null)
            {
                return NotFound();
            }
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientExists(Guid id)
        {
            return (_context.Ingredients?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
