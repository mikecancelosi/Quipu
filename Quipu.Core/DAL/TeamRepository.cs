using Microsoft.EntityFrameworkCore;
using Quipu.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quipu.Core.DAL
{
    public class TeamRepository : IRepository<Team>
    {
        private readonly QContext _context;

        public async Task<Team> Create(Team instance)
        {
            _context.Teams.Add(instance);
            await _context.SaveChangesAsync();
            return instance;
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var InstanceToDelete = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(InstanceToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Team>> Get()
        {
            return await _context.Teams.ToListAsync();
        }

        public async System.Threading.Tasks.Task Update(Team instance)
        {
            _context.Entry(instance).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
