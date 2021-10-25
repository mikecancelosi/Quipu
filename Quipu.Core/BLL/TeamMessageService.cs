using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class TeamMessageService : IModelService<TeamMessage>
    {
        private QContext _context;

        public TeamMessageService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<TeamMessage>>> Get()
        {
            return await _context.TeamMessages.ToListAsync();
        }

        public async Task<ActionResult<TeamMessage>> Get(int id)
        {
            var entity = await _context.TeamMessages.FindAsync(id);
            return entity;
        }

        public async Task<bool> Put(TeamMessage entity)
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

        public async Task<TeamMessage> Post(TeamMessage entity)
        {
            _context.TeamMessages.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.TeamMessages.FindAsync(id);
            _context.TeamMessages.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.TeamMessages.Any(x => x.ID == id);
        }
    }
}