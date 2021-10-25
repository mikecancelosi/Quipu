using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{
    public class DiscussionService : IModelService<Discussion>
    {
        private QContext _context;
        public DiscussionService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Discussion>>> Get()
        {
            return await _context.Discussions.ToListAsync();
        }

        public async Task<ActionResult<Discussion>> Get(int id)
        {
            var discussion = await _context.Discussions.FindAsync(id);

            return discussion;
        }

        public async Task<bool> Put(Discussion discussion)
        {
            _context.Entry(discussion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscussionExists(discussion.ID))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Discussion> Post(Discussion discussion)
        {
            _context.Discussions.Add(discussion);
            await _context.SaveChangesAsync();

            return discussion;
        }

        public async Task<bool> Delete(int id)
        {
            var task = await _context.Discussions.FindAsync(id);
            _context.Discussions.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool DiscussionExists(int id)
        {
            return _context.Discussions.Any(e => e.ID == id);
        }
    }
}
