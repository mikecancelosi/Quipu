using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quipu.Core.BLL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionGroupsController : ControllerBase
    {
        private readonly IModelService<PermissionGroup> _modelService;

        public PermissionGroupsController(IModelService<PermissionGroup> service)
        {
            _modelService = service;
        }

        // GET: api/PermissionGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PermissionGroup>>> GetPermissionGroups()
        {
            return await _modelService.Get();
        }

        // GET: api/PermissionGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PermissionGroup>> GetPermissionGroup(int id)
        {
            var entity = await _modelService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/PermissionGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermissionGroup(int id, PermissionGroup entity)
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

        // POST: api/PermissionGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PermissionGroup>> PostPermissionGroup(PermissionGroup entity)
        {
            var postedEntity = await _modelService.Post(entity);
            if (postedEntity != null)
            {
                return CreatedAtAction("GetPermissionGroup", new { id = postedEntity.ID }, postedEntity);
            }

            return BadRequest();
        }

        // DELETE: api/PermissionGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermissionGroup(int id)
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