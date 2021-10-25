using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class TaskStatusCategoryService : IModelService<TaskStatusCategory>
    {
        private QContext _context;

        public TaskStatusCategoryService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<TaskStatusCategory>>> Get()
        {
            return await _context.TaskStatusCategories.ToListAsync();
        }

        public async Task<ActionResult<TaskStatusCategory>> Get(int id)
        {
            var entity = await _context.TaskStatusCategories.FindAsync(id);
            return entity;
        }

        public async Task<bool> Put(TaskStatusCategory entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(entity.ID))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<TaskStatusCategory> Post(TaskStatusCategory entity)
        {
            _context.TaskStatusCategories.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.TaskStatusCategories.FindAsync(id);
            _context.TaskStatusCategories.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.TaskStatusCategories.Any(x => x.ID == id);
        }
    }
}