using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class TaskService : IModelService<DomainModel.Task>
    {
        private QContext _context;
        public TaskService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<DomainModel.Task>>> Get()
        {

            return await _context.Tasks.Include(t=>t.Revisions)
                                            .ThenInclude(r => r.User)
                                       .Include(t=>t.Status)
                                       .Include(t=>t.StatusCategory)
                                       .Include(t=>t.Priority)
                                       .Include(t=>t.DiscussionOwner)
                                            .ThenInclude(o=>o.Discussions)
                                        .Include(t=>t.AssignedToUser)
                                       .AsSplitQuery()
                                       .ToListAsync();
        }

        public async Task<ActionResult<DomainModel.Task>> Get(int id)
        {

            var task = await _context.Tasks.Include(t=>t.Revisions)
                                           .Include(t=>t.Status)
                                           .Include(t=>t.Priority)
                                           .AsSplitQuery()
                                           .FirstAsync(t => t.ID == id);

            return task;
        }

        public async Task<bool> Put(DomainModel.Task task)
        {
            task.ProjectID = task.Project?.ID ?? task.ProjectID;
            task.StatusCategoryID = task.StatusCategory?.ID ?? task.StatusCategoryID;
            task.AssignedToUserID = task.AssignedToUser?.ID ?? task.AssignedToUserID;
            task.PriorityID = task.Priority?.ID ?? task.PriorityID;
            task.StatusID = task.Status?.ID ?? task.StatusID;

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(task.ID))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }
        }
      
        public async Task<DomainModel.Task> Post(DomainModel.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return task;
        }
       
        public async Task<bool> Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.ID == id);
        }
    }
}
