using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quipu.Core.BLL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPermissionOverridesController : ControllerBase
    {
        private readonly IModelService<UserPermissionOverride> _modelService;

        public UserPermissionOverridesController(IModelService<UserPermissionOverride> service)
        {
            _modelService = service;
        }

        // GET: api/UserPermissionOverrides
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPermissionOverride>>> GetUserPermissionOverrides()
        {
            return await _modelService.Get();
        }

        // GET: api/UserPermissionOverrides/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPermissionOverride>> GetUserPermissionOverride(int id)
        {
            var entity = await _modelService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/UserPermissionOverrides/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPermissionOverride(int id, UserPermissionOverride entity)
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

        // POST: api/UserPermissionOverrides
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPermissionOverride>> PostUserPermissionOverride(UserPermissionOverride entity)
        {
            var postedEntity = await _modelService.Post(entity);
            if (postedEntity != null)
            {
                return CreatedAtAction("GetUserPermissionOverride", new { id = postedEntity.ID }, postedEntity);
            }

            return BadRequest();
        }

        // DELETE: api/UserPermissionOverrides/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPermissionOverride(int id)
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