using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quipu.Core.BLL;
using Quipu.Core.DAL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscussionsController : ControllerBase
    {
        private readonly IModelService<Discussion> _modelService;

        public DiscussionsController(IModelService<Discussion> service)
        {
            _modelService = service;
        }

        // GET: api/Discussions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discussion>>> GetDiscussions()
        {
            return await _modelService.Get();
        }

        // GET: api/Discussions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Discussion>> GetDiscussion(int id)
        {
            var discussion = await _modelService.Get(id);

            if (discussion == null)
            {
                return NotFound();
            }

            return discussion;
        }

        // PUT: api/Discussions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscussion(int id, Discussion discussion)
        {
            if (id != discussion.ID)
            {
                return BadRequest();
            }

            if (await _modelService.Put(discussion))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Discussions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Discussion>> PostDiscussion(Discussion discussion)
        {
            var postedDiscussion = await _modelService.Post(discussion);
            if (postedDiscussion != null)
            {
                return CreatedAtAction("GetDiscussion", new { id = postedDiscussion.ID }, postedDiscussion);
            }

            return BadRequest();
        }

        // DELETE: api/Discussions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscussion(int id)
        {
            var discussion = await _modelService.Get(id);
            if (discussion == null)
            {
                return NotFound();
            }

            if (await _modelService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
