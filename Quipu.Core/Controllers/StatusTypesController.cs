using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quipu.Core.BLL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTypesController : ControllerBase
    {
        private readonly IModelService<StatusType> _modelService;

        public StatusTypesController(IModelService<StatusType> service)
        {
            _modelService = service;
        }

        // GET: api/StatusTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusType>>> GetStatusTypes()
        {
            return await _modelService.Get();
        }

        // GET: api/StatusTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusType>> GetStatusType(int id)
        {
            var entity = await _modelService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/StatusTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatusType(int id, StatusType entity)
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

        // POST: api/StatusTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StatusType>> PostStatusType(StatusType entity)
        {
            var postedEntity = await _modelService.Post(entity);
            if (postedEntity != null)
            {
                return CreatedAtAction("GetStatusType", new { id = postedEntity.ID }, postedEntity);
            }

            return BadRequest();
        }

        // DELETE: api/StatusTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusType(int id)
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