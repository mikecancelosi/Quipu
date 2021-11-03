using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quipu.Core.BLL;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IModelService<DomainModel.Task> modelService;

        public TasksController(IModelService<DomainModel.Task> service)
        {
            modelService = service;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DomainModel.Task>>> GetTasks()
        {
            return await modelService.Get();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DomainModel.Task>> GetTask(int id)
        {
            var task = await modelService.Get(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, DomainModel.Task task)
        {
            if (id != task.ID)
            {
                return BadRequest();
            }

            if(await modelService.Put(task))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        // POST: api/Tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DomainModel.Task>> PostTask(DomainModel.Task task)
        {
            DomainModel.Task postedTask = await modelService.Post(task);
            if(postedTask != null)
            {
                return Ok(postedTask);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await modelService.Delete(id);

            return NoContent();
        }
    }
}
