using AutoMapper;
using IntraNet.Entities;
using IntraNet.Exceptions;
using IntraNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IntraNet.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Employee> _passwordHasher;
        private readonly IntraNetDbContext _context;
        public EmployeeService(IntraNetDbContext context, IMapper mapper, IPasswordHasher<Employee> passwordHasher)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<EmployeeDto> GetById(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.TasksAssigned)
                .FirstOrDefaultAsync(e => e.Id == id);
                
                

            if (employee is null)
                throw new NotFoundException("Employee not found"); 

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            if (employeeDto == null)
            {
                throw new NotFoundException("Mapping failed");
            }
            return employeeDto;

        }
        public async Task<IEnumerable<EmployeeDto>> GetAll(string searchPhrase)
        {
            //maping data from database to dto model to hide unwanted data to client
            var employees = await _context.Employees
                .Include(e => e.TasksAssigned)
                .Where(e=> searchPhrase == null || (e.FirstName.ToLower().Contains(searchPhrase.ToLower())|| e.LastName.ToLower().Contains(searchPhrase.ToLower())))
                .ToListAsync();
            var employeesDtos = _mapper.Map<List<EmployeeDto>>(employees);

            return employeesDtos;
        }

        public async Task<int> CreateEmployee(CreateEmployeeDto employeeDto)
        {
            
            var newEmployee = _mapper.Map<Employee>(employeeDto);
            
            var hashedPassword =_passwordHasher.HashPassword(newEmployee, employeeDto.Password);
            newEmployee.Password = hashedPassword;

            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return newEmployee.Id;
        }

        public async Task DeleteEmployeeById(int id)
        {
            var Employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (Employee is null)
                throw new NotFoundException("Employee not found");
            _context.Employees.Remove(Employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployee(int id, UpdateEmployeeDto dto)
        {
            var Employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (Employee is null) 
                throw new NotFoundException("Employee not found");
            Employee.Email = dto.Email;
            Employee.Position = dto.Position;
            Employee.Status = dto.Status;
            await _context.SaveChangesAsync();
        }
    }
}
