using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class UserService : IModelService<User>
    {
        private QContext _context;
        public UserService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<User>> Get(int id)
        {
            var users = await _context.Users.FindAsync(id);

            return users;
        }

        public async Task<bool> Put(User discussion)
        {
            _context.Entry(discussion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(discussion.ID))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<User> Post(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            var task = await _context.Users.FindAsync(id);
            _context.Users.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }
    }
}
