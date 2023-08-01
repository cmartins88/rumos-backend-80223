using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SnackMachinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SnackMachinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SnackMachines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SnackMachine>>> GetSnackMachines()
        {
          if (_context.SnackMachines == null)
          {
              return NotFound();
          }
            return await _context.SnackMachines.ToListAsync();
        }

        // GET: api/SnackMachines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SnackMachine>> GetSnackMachine(Guid id)
        {
          if (_context.SnackMachines == null)
          {
              return NotFound();
          }
            var snackMachine = await _context.SnackMachines.FindAsync(id);

            if (snackMachine == null)
            {
                return NotFound();
            }

            return snackMachine;
        }

        // PUT: api/SnackMachines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSnackMachine(Guid id, SnackMachine snackMachine)
        {
            if (id != snackMachine.Id)
            {
                return BadRequest();
            }

            _context.Entry(snackMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnackMachineExists(id))
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

        // POST: api/SnackMachines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SnackMachine>> PostSnackMachine(SnackMachine snackMachine)
        {
          if (_context.SnackMachines == null)
          {
              return Problem("Entity set 'ApplicationDbContext.SnackMachines'  is null.");
          }
            _context.SnackMachines.Add(snackMachine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSnackMachine", new { id = snackMachine.Id }, snackMachine);
        }

        // DELETE: api/SnackMachines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSnackMachine(Guid id)
        {
            if (_context.SnackMachines == null)
            {
                return NotFound();
            }
            var snackMachine = await _context.SnackMachines.FindAsync(id);
            if (snackMachine == null)
            {
                return NotFound();
            }

            _context.SnackMachines.Remove(snackMachine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SnackMachineExists(Guid id)
        {
            return (_context.SnackMachines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
