using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quipu.Core.BLL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMessagesController : ControllerBase
    {
        private readonly IModelService<TeamMessage> _modelService;

        public TeamMessagesController(IModelService<TeamMessage> service)
        {
            _modelService = service;
        }

        // GET: api/TeamMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMessage>>> GetTeamMessages()
        {
            return await _modelService.Get();
        }

        // GET: api/TeamMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMessage>> GetTeamMessage(int id)
        {
            var entity = await _modelService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/TeamMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeamMessage(int id, TeamMessage entity)
        {
            if (id != entity.ID)
            {
                return BadRequest();
            }

            if (await _modelService.Put(entity))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/TeamMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TeamMessage>> PostTeamMessage(TeamMessage entity)
        {
            var postedEntity = await _modelService.Post(entity);
            if (postedEntity != null)
            {
                return CreatedAtAction("GetTeamMessage", new { id = postedEntity.ID }, postedEntity);
            }

            return BadRequest();
        }

        // DELETE: api/TeamMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMessage(int id)
        {
            var entity = await _modelService.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            if (await _modelService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}