using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quipu.Core.BLL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskRevisionsController : ControllerBase
    {
        private readonly IModelService<TaskRevision> _modelService;

        public TaskRevisionsController(IModelService<TaskRevision> service)
        {
            _modelService = service;
        }

        // GET: api/TaskRevisions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskRevision>>> GetTaskRevisions()
        {
            return await _modelService.Get();
        }

        // GET: api/TaskRevisions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskRevision>> GetTaskRevision(int id)
        {
            var entity = await _modelService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/TaskRevisions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskRevision(int id, TaskRevision entity)
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

        // POST: api/TaskRevisions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskRevision>> PostTaskRevision(TaskRevision entity)
        {
            var postedEntity = await _modelService.Post(entity);
            if (postedEntity != null)
            {
                return CreatedAtAction("GetTaskRevision", new { id = postedEntity.ID }, postedEntity);
            }

            return BadRequest();
        }

        // DELETE: api/TaskRevisions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskRevision(int id)
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