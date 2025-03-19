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
        public async Task<ActionResult<EmployeeDto>>UpdateEmployee([FromRoute]int id, [FromBody]UpdateEmployeeDto dto)
        {           
            await _employeeService.UpdateEmployee(id, dto);           
             return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteEmployee([FromRoute]int id)
        {        
            await _employeeService.DeleteEmployeeById(id);                  
            return NoContent();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] 
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeDto dto)
        { 
            int id = await _employeeService.CreateEmployee(dto);
            return Created($"/api/intranet/{id}", null);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll([FromQuery] string searchPhrase)
        {
            //maping data from database to dto model to hide unwanted data to client
            var employees = await _employeeService.GetAll(searchPhrase);
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetById([FromRoute]int id)
        {
           var employee = await _employeeService.GetById(id);
           return Ok(employee);
        }
    }
}
