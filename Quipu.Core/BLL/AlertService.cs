using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class AlertService : IModelService<Alert>
    {
        private QContext _context;

        public AlertService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Alert>>> Get()
        {
            return await _context.Alerts.ToListAsync();
        }

        public async Task<ActionResult<Alert>> Get(int id)
        {
            var entity = await _context.Alerts.FindAsync(id);
            return entity;
        }

        public async Task<bool> Put(Alert entity)
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

        public async Task<Alert> Post(Alert entity)
        {
            _context.Alerts.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Alerts.FindAsync(id);
            _context.Alerts.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.Alerts.Any(x => x.ID == id);
        }
    }
}