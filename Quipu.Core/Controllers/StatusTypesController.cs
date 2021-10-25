﻿using System;
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
    public class StatusTypesController : ControllerBase
    {
        private readonly QContext _context;

        public StatusTypesController(QContext context)
        {
            _context = context;
        }

        // GET: api/StatusTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusType>>> GetStatusType()
        {
            return await _context.StatusTypes.ToListAsync();
        }

        // GET: api/StatusTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusType>> GetStatusType(int id)
        {
            var statusType = await _context.StatusTypes.FindAsync(id);

            if (statusType == null)
            {
                return NotFound();
            }

            return statusType;
        }

        // PUT: api/StatusTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusType(int id, StatusType statusType)
        {
            if (id != statusType.ID)
            {
                return BadRequest();
            }

            _context.Entry(statusType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusTypeExists(id))
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

        // POST: api/StatusTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusType>> PostStatusType(StatusType statusType)
        {
            _context.StatusTypes.Add(statusType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStatusType", new { id = statusType.ID }, statusType);
        }

        // DELETE: api/StatusTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusType(int id)
        {
            var statusType = await _context.StatusTypes.FindAsync(id);
            if (statusType == null)
            {
                return NotFound();
            }

            _context.StatusTypes.Remove(statusType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatusTypeExists(int id)
        {
            return _context.StatusTypes.Any(e => e.ID == id);
        }
    }
}
