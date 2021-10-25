using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class StatusTypeService : IModelService<StatusType>
    {
        private QContext _context;

        public StatusTypeService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<StatusType>>> Get()
        {
            return await _context.StatusTypes.ToListAsync();
        }

        public async Task<ActionResult<StatusType>> Get(int id)
        {
            var entity = await _context.StatusTypes.FindAsync(id);
            return entity;
        }

        public async Task<bool> Put(StatusType entity)
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

        public async Task<StatusType> Post(StatusType entity)
        {
            _context.StatusTypes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.StatusTypes.FindAsync(id);
            _context.StatusTypes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.StatusTypes.Any(x => x.ID == id);
        }
    }
}