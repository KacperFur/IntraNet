using IntraNet.Entities;
using IntraNet.Models;
using IntraNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntraNet.Controllers
{
    [Route("api/intranet/event")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
    {

        private readonly IEventService _service;
        public EventController(IEventService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<ActionResult> CreateEvent([FromBody]CreateEventDto dto, CancellationToken cancellationToken)
        {
            int id = await _service.CreateEvent(dto, cancellationToken);
            return Created($"/api/event/{id}", null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetAll([FromQuery]EventQuery query, CancellationToken cancellationToken) 
        {
            var results = await _service.GetAll(query, cancellationToken);
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetById([FromRoute]int id, CancellationToken cancellationToken)
        {
            var result = await _service.GetById(id, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEvent([FromRoute] int id, CancellationToken cancellationToken)
        {
            await _service.DeleteEvent(id, cancellationToken);
            return NoContent();
        }
    }
}
