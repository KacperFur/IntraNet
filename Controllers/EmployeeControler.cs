using AutoMapper;
using IntraNet.Entities;
using IntraNet.Models;
using IntraNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntraNet.Controllers
{
    [Route("api/intranet/employee")]
    [ApiController]
    [Authorize]
    public class EmployeeControler : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeControler(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<EmployeeDto>>UpdateEmployee([FromRoute]int id, [FromBody]UpdateEmployeeDto dto, CancellationToken cancellationToken)
        {           
            await _employeeService.UpdateEmployee(id, dto, cancellationToken);           
             return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteEmployee([FromRoute]int id, CancellationToken cancellationToken)
        {        
            await _employeeService.DeleteEmployeeById(id, cancellationToken);                  
            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto, CancellationToken cancellationToken)
        { 
            int id = await _employeeService.CreateEmployee(dto, cancellationToken);
            return Created($"/api/intranet/{id}", null);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll([FromQuery] EmployeeQuery query, CancellationToken cancellationToken)
        {
            var employees = await _employeeService.GetAll(query, cancellationToken);
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetById([FromRoute]int id, CancellationToken cancellationToken)
        {
           var employee = await _employeeService.GetById(id, cancellationToken);
           return Ok(employee);
        }
    }
}
