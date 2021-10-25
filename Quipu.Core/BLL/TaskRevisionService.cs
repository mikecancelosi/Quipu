using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class TaskRevisionService : IModelService<TaskRevision>
    {
        private QContext _context;

        public TaskRevisionService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<TaskRevision>>> Get()
        {
            return await _context.TaskRevisions.ToListAsync();
        }

        public async Task<ActionResult<TaskRevision>> Get(int id)
        {
            var entity = await _context.TaskRevisions.FindAsync(id);
            return entity;
        }

        public async Task<bool> Put(TaskRevision entity)
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

        public async Task<TaskRevision> Post(TaskRevision entity)
        {
            _context.TaskRevisions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.TaskRevisions.FindAsync(id);
            _context.TaskRevisions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.TaskRevisions.Any(x => x.ID == id);
        }
    }
}