using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quipu.Core.BLL
{
    public class PriorityTypeService : IModelService<PriorityType>
    {
        private QContext _context;
        public PriorityTypeService(QContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<PriorityType>>> Get()
        {
            return await _context.PriorityTypes.ToListAsync();
        }

        public async Task<ActionResult<PriorityType>> Get(int id)
        {
            var priorityType = await _context.PriorityTypes.FindAsync(id);

            return priorityType;
        }

        public async Task<bool> Put(PriorityType priorityType)
        {
            _context.Entry(priorityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(priorityType.ID))
                {
                    throw;
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<PriorityType> Post(PriorityType priorityType)
        {
            _context.PriorityTypes.Add(priorityType);
            await _context.SaveChangesAsync();

            return priorityType;
        }

        public async Task<bool> Delete(int id)
        {
            var priorityType = await _context.PriorityTypes.FindAsync(id);
            _context.PriorityTypes.Remove(priorityType);
            await _context.SaveChangesAsync();
            return true;
        }

        private bool EntityExists(int id)
        {
            return _context.PriorityTypes.Any(e => e.ID == id);
        }
    }
}
