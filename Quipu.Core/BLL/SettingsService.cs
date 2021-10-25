using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class SettingsService : IModelService<Settings>
    {
        private QContext _context;

        public SettingsService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Settings>>> Get()
        {
            return await _context.Settings.ToListAsync();
        }

        public async Task<ActionResult<Settings>> Get(int id)
        {
            var entity = await _context.Settings.FindAsync(id);
            return entity;
        }

        public async Task<bool> Put(Settings entity)
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

        public async Task<Settings> Post(Settings entity)
        {
            _context.Settings.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Settings.FindAsync(id);
            _context.Settings.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.Settings.Any(x => x.ID == id);
        }
    }
}