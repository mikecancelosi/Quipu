using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class TeamService : IModelService<Team>
    {
        private QContext _context;

        public TeamService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Team>>> Get()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<ActionResult<Team>> Get(int id)
        {
            var entity = await _context.Teams.FindAsync(id);
            return entity;
        }

        public async Task<bool> Put(Team entity)
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

        public async Task<Team> Post(Team entity)
        {
            _context.Teams.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Teams.FindAsync(id);
            _context.Teams.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.Teams.Any(x => x.ID == id);
        }
    }
}