using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Quipu.Core.BLL
{
    public class ProjectService : IModelService<Project>
    {
        private QContext _context;
        public ProjectService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<ActionResult<Project>> Get(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            _context.Entry(project).Collection(p => p.Tasks).Load();
            foreach (var task in project.Tasks)
            {
                _context.Entry(task).Reference(t => t.StatusCategory).Load();
                _context.Entry(task).Reference(t => t.Status).Load();
                _context.Entry(task).Reference(t => t.Priority).Load();
                _context.Entry(task).Reference(t => t.AssignedToUser).Load();
            }

            return project;
        }

        public async Task<bool> Put(Project priorityType)
        {
            _context.Entry(priorityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(priorityType.ID))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Project> Post(Project priorityType)
        {
            _context.Projects.Add(priorityType);
            await _context.SaveChangesAsync();

            return priorityType;
        }

        public async Task<bool> Delete(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.Projects.Any(e => e.ID == id);
        }
    }
}
