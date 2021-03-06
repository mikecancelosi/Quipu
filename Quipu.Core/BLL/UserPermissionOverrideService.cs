using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class UserPermissionOverrideService : IModelService<UserPermissionOverride>
    {
        private QContext _context;

        public UserPermissionOverrideService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<UserPermissionOverride>>> Get()
        {
            return await _context.UserPermissionOverrides.ToListAsync();
        }

        public async Task<ActionResult<UserPermissionOverride>> Get(int id)
        {
            var entity = await _context.UserPermissionOverrides.FindAsync(id);
            return entity;
        }

        public async Task<bool> Put(UserPermissionOverride entity)
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

        public async Task<UserPermissionOverride> Post(UserPermissionOverride entity)
        {
            _context.UserPermissionOverrides.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _context.UserPermissionOverrides.FindAsync(id);
            _context.UserPermissionOverrides.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.UserPermissionOverrides.Any(x => x.ID == id);
        }
    }
}