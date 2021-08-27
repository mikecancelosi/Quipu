using Microsoft.EntityFrameworkCore;
using Quipu.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quipu.Core.DAL
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly QContext _context;

        public async Task<Project> Create(Project instance)
        {
            _context.Projects.Add(instance);
            await _context.SaveChangesAsync();
            return instance;
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var InstanceToDelete = await _context.Projects.FindAsync(id);
            _context.Projects.Remove(InstanceToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> Get()
        {
            return await _context.Projects.ToListAsync();
        }

        public async System.Threading.Tasks.Task Update(Project instance)
        {
            _context.Entry(instance).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
