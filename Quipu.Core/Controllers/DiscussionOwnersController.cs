using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quipu.Core.BLL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscussionOwnersController : ControllerBase
    {
        private readonly IModelService<DiscussionOwner> _modelService;

        public DiscussionOwnersController(IModelService<DiscussionOwner> service)
        {
            _modelService = service;
        }

        // GET: api/DiscussionOwners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscussionOwner>>> GetDiscussionOwners()
        {
            return await _modelService.Get();
        }

        // GET: api/DiscussionOwners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DiscussionOwner>> GetDiscussionOwner(int id)
        {
            var entity = await _modelService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/DiscussionOwners/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscussionOwner(int id, DiscussionOwner entity)
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

        // POST: api/DiscussionOwners
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DiscussionOwner>> PostDiscussionOwner(DiscussionOwner entity)
        {
            var postedEntity = await _modelService.Post(entity);
            if (postedEntity != null)
            {
                return CreatedAtAction("GetDiscussionOwner", new { id = postedEntity.ID }, postedEntity);
            }

            return BadRequest();
        }

        // DELETE: api/DiscussionOwners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscussionOwner(int id)
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