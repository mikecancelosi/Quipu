using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quipu.Core.BLL;
using Quipu.Core.DomainModel;

namespace Quipu.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlertsController : ControllerBase
    {
        private readonly IModelService<Alert> _modelService;

        public AlertsController(IModelService<Alert> service)
        {
            _modelService = service;
        }

        // GET: api/Alerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alert>>> GetAlerts()
        {
            return await _modelService.Get();
        }

        // GET: api/Alerts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alert>> GetAlert(int id)
        {
            var entity = await _modelService.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        // PUT: api/Alerts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlert(int id, Alert entity)
        {
            if (id != entity.ID)
            {
                return BadRequest();
            }

            if (await _modelService.Put(entity))
            {
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/Alerts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alert>> PostAlert(Alert entity)
        {
            var postedEntity = await _modelService.Post(entity);
            if (postedEntity != null)
            {
                return CreatedAtAction("GetAlert", new { id = postedEntity.ID }, postedEntity);
            }

            return BadRequest();
        }

        // DELETE: api/Alerts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlert(int id)
        {
            var entity = await _modelService.Get(id);
            if (entity == null)
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