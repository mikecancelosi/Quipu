using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quipu.Core.BLL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusCategoriesController : ControllerBase
    {
        private readonly IModelService<TaskStatusCategory> _modelService;

        public TaskStatusCategoriesController(IModelService<TaskStatusCategory> service)
        {
            _modelService = service;
        }

        // GET: api/TaskStatusCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskStatusCategory>>> GetTaskStatusCategories()
        {
            return await _modelService.Get();
        }

        // GET: api/TaskStatusCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskStatusCategory>> GetTaskStatusCategory(int id)
        {
            var entity = await _modelService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/TaskStatusCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskStatusCategory(int id, TaskStatusCategory entity)
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

        // POST: api/TaskStatusCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskStatusCategory>> PostTaskStatusCategory(TaskStatusCategory entity)
        {
            var postedEntity = await _modelService.Post(entity);
            if (postedEntity != null)
            {
                return CreatedAtAction("GetTaskStatusCategory", new { id = postedEntity.ID }, postedEntity);
            }

            return BadRequest();
        }

        // DELETE: api/TaskStatusCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskStatusCategory(int id)
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