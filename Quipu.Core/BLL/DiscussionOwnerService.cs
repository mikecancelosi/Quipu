using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.BLL
{public class DiscussionOwnerService : IModelService<DiscussionOwner>
{
	private QContext _context;

public DiscussionOwnerService(QContext context)
{
	_context = context;}

public async Task<ActionResult<IEnumerable<DiscussionOwner>>> Get() {
	return await _context.DiscussionOwners.ToListAsync();
}

public async Task<ActionResult<DiscussionOwner>> Get(int id)
{
	var entity = await _context.DiscussionOwners.FindAsync(id);
return entity;
}

public async Task<bool> Put(DiscussionOwner entity)
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

public async Task<DiscussionOwner> Post(DiscussionOwner entity)
{
	_context.DiscussionOwners.Add(entity);
	await _context.SaveChangesAsync();
	return entity;
}

public async Task<bool> Delete(int id)
{
	var entity = await _context.DiscussionOwners.FindAsync(id);
	_context.DiscussionOwners.Remove(entity);
	await _context.SaveChangesAsync();
return true;
}

private bool EntityExists(int id)
{
	return _context.DiscussionOwners.Any(x =>x.ID == id);
}
}
}