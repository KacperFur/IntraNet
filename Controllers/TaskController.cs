using IntraNet.Entities;
using IntraNet.Models;
using IntraNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IntraNet.Controllers
{
    [Route("api/intranet/task")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<ActionResult> Delete([FromRoute]int id, CancellationToken cancellationToken)
        { 
            await _service.DeleteTask(id, cancellationToken);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTaskDto>>> GetAll([FromQuery]EmployeeTaskQuery query, CancellationToken cancellationToken)
        {
            var result = await _service.GetAll(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTaskDto>> GetByEmployeeId([FromRoute]int id, CancellationToken cancellationToken)
        {
            var result = await _service.GetByEmployeeId(id, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<ActionResult> CreateTask([FromBody]CreateEmployeeTaskDto dto, CancellationToken cancellationToken) 
        {
            int id = await _service.CreateTask(dto, cancellationToken);
            return Created($"/api/task/{id}", null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<ActionResult> UpdateTask([FromRoute]int id, [FromBody] UpdateEmployeeTaskDto dto, CancellationToken cancellationToken)
        {
            await _service.UpdateTask(dto, id, cancellationToken);
            return Ok();
        }
    }
}
