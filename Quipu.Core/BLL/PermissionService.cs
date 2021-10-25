using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class PermissionService : IModelService<Permission>
    {
        private QContext _context;

        public PermissionService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Permission>>> Get()
        {
            return await _context.Permissions.ToListAsync();
        }

        public async Task<ActionResult<Permission>> Get(int id)
        {
            var entity = await _context.Permissions.FindAsync(id);
            return entity;
        }

        public async Task<bool> Put(Permission entity)
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

        public async Task<Permission> Post(Permission entity)
        {
            _context.Permissions.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.Permissions.FindAsync(id);
            _context.Permissions.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.Permissions.Any(x => x.ID == id);
        }
    }
}