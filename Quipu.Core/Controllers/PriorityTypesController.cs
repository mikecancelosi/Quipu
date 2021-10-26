using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quipu.Core.BLL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriorityTypesController : ControllerBase
    {
        private readonly IModelService<PriorityType> _modelService;

        public PriorityTypesController(IModelService<PriorityType> service)
        {
            _modelService = service;
        }

        // GET: api/PriorityTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PriorityType>>> GetPriorityTypes()
        {
            return await _modelService.Get();
        }

        // GET: api/PriorityTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PriorityType>> GetPriorityType(int id)
        {
            var entity = await _modelService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/PriorityTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriorityType(int id, PriorityType entity)
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

        // POST: api/PriorityTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PriorityType>> PostPriorityType(PriorityType entity)
        {
            var postedEntity = await _modelService.Post(entity);
            if (postedEntity != null)
            {
                return CreatedAtAction("GetPriorityType", new { id = postedEntity.ID }, postedEntity);
            }

            return BadRequest();
        }

        // DELETE: api/PriorityTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriorityType(int id)
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