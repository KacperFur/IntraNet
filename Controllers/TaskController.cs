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
        public async Task<ActionResult> Delete([FromRoute]int id)
        { 
            await _service.DeleteTask(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeTaskDto>>> GetAll()
        {
            var result = await _service.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeTaskDto>> GetByEmployeeId([FromRoute]int id)
        {
            var result = await _service.GetByEmployeeId(id);
            return Ok(result);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<ActionResult> CreateTask([FromBody]CreateEmployeeTaskDto dto) 
        {
            int id = await _service.CreateTask(dto);
            return Created($"/api/task/{id}", null);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Supervisor")]
        public async Task<ActionResult> UpdateTask([FromRoute]int id, [FromBody] UpdateEmployeeTaskDto dto)
        {
            await _service.UpdateTask(dto, id);
            return Ok();
        }
    }
}
