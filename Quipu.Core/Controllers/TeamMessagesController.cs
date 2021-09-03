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
    public class TeamMessagesController : ControllerBase
    {
        private readonly QContext _context;

        public TeamMessagesController(QContext context)
        {
            _context = context;
        }

        // GET: api/TeamMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMessage>>> GetTeamMessages()
        {
            return await _context.TeamMessages.ToListAsync();
        }

        // GET: api/TeamMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMessage>> GetTeamMessage(int id)
        {
            var teamMessage = await _context.TeamMessages.FindAsync(id);

            if (teamMessage == null)
            {
                return NotFound();
            }

            return teamMessage;
        }

        // PUT: api/TeamMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMessage(int id, TeamMessage teamMessage)
        {
            if (id != teamMessage.ID)
            {
                return BadRequest();
            }

            _context.Entry(teamMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMessageExists(id))
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

        // POST: api/TeamMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamMessage>> PostTeamMessage(TeamMessage teamMessage)
        {
            _context.TeamMessages.Add(teamMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTeamMessage", new { id = teamMessage.ID }, teamMessage);
        }

        // DELETE: api/TeamMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMessage(int id)
        {
            var teamMessage = await _context.TeamMessages.FindAsync(id);
            if (teamMessage == null)
            {
                return NotFound();
            }

            _context.TeamMessages.Remove(teamMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TeamMessageExists(int id)
        {
            return _context.TeamMessages.Any(e => e.ID == id);
        }
    }
}
