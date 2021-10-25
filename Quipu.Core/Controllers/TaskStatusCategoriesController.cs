using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusCategoriesController : ControllerBase
    {
        private readonly QContext _context;

        public TaskStatusCategoriesController(QContext context)
        {
            _context = context;
        }

        // GET: api/TaskStatusCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskStatusCategory>>> GetTaskStatusCategory()
        {
            return await _context.TaskStatusCategories.ToListAsync();
        }

        // GET: api/TaskStatusCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskStatusCategory>> GetTaskStatusCategory(int id)
        {
            var taskStatusCategory = await _context.TaskStatusCategories.FindAsync(id);

            if (taskStatusCategory == null)
            {
                return NotFound();
            }

            return taskStatusCategory;
        }

        // PUT: api/TaskStatusCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskStatusCategory(int id, TaskStatusCategory taskStatusCategory)
        {
            if (id != taskStatusCategory.ID)
            {
                return BadRequest();
            }

            _context.Entry(taskStatusCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskStatusCategoryExists(id))
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

        // POST: api/TaskStatusCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskStatusCategory>> PostTaskStatusCategory(TaskStatusCategory taskStatusCategory)
        {
            _context.TaskStatusCategories.Add(taskStatusCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskStatusCategory", new { id = taskStatusCategory.ID }, taskStatusCategory);
        }

        // DELETE: api/TaskStatusCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskStatusCategory(int id)
        {
            var taskStatusCategory = await _context.TaskStatusCategories.FindAsync(id);
            if (taskStatusCategory == null)
            {
                return NotFound();
            }

            _context.TaskStatusCategories.Remove(taskStatusCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskStatusCategoryExists(int id)
        {
            return _context.TaskStatusCategories.Any(e => e.ID == id);
        }
    }
}
