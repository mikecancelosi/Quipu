using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityTypesController : ControllerBase
    {
        private readonly QContext _context;

        public PriorityTypesController(QContext context)
        {
            _context = context;
        }

        // GET: api/PriorityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriorityType>>> GetPriorityType()
        {
            return await _context.PriorityTypes.ToListAsync();
        }

        // GET: api/PriorityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriorityType>> GetPriorityType(int id)
        {
            var priorityType = await _context.PriorityTypes.FindAsync(id);

            if (priorityType == null)
            {
                return NotFound();
            }

            return priorityType;
        }

        // PUT: api/PriorityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriorityType(int id, PriorityType priorityType)
        {
            if (id != priorityType.ID)
            {
                return BadRequest();
            }

            _context.Entry(priorityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PriorityTypeExists(id))
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

        // POST: api/PriorityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PriorityType>> PostPriorityType(PriorityType priorityType)
        {
            _context.PriorityTypes.Add(priorityType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPriorityType", new { id = priorityType.ID }, priorityType);
        }

        // DELETE: api/PriorityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriorityType(int id)
        {
            var priorityType = await _context.PriorityTypes.FindAsync(id);
            if (priorityType == null)
            {
                return NotFound();
            }

            _context.PriorityTypes.Remove(priorityType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PriorityTypeExists(int id)
        {
            return _context.PriorityTypes.Any(e => e.ID == id);
        }
    }
}
