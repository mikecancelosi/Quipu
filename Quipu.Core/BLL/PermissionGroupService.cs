using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class PermissionGroupService : IModelService<PermissionGroup>
    {
        private QContext _context;

        public PermissionGroupService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<PermissionGroup>>> Get()
        {
            return await _context.PermissionGroups.ToListAsync();
        }

        public async Task<ActionResult<PermissionGroup>> Get(int id)
        {
            var entity = await _context.PermissionGroups.FindAsync(id);
            return entity;
        }

        public async Task<bool> Put(PermissionGroup entity)
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

        public async Task<PermissionGroup> Post(PermissionGroup entity)
        {
            _context.PermissionGroups.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.PermissionGroups.FindAsync(id);
            _context.PermissionGroups.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.PermissionGroups.Any(x => x.ID == id);
        }
    }
}