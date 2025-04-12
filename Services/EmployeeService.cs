using AutoMapper;
using IntraNet.Entities;
using IntraNet.Exceptions;
using IntraNet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading;

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

        public async Task<EmployeeDto> GetById(int id, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees
                .AsNoTracking()
                .Include(e => e.TasksAssigned)
                .Include(e => e.Events)
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
                
                

            if (employee is null)
                throw new NotFoundException("Employee not found"); 

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            if (employeeDto == null)
            {
                throw new NotFoundException("Mapping failed");
            }
            return employeeDto;

        }
        public async Task<PagedResult<EmployeeDto>> GetAll(EmployeeQuery query, CancellationToken cancellationToken)
        {
            //maping data from database to dto model to hide unwanted data to client
            var employees = await _context.Employees
                .Include(e => e.TasksAssigned)
                .Include(e => e.Events)
                .AsNoTracking()
                .Where(e=> query.SearchPhrase == null || (e.FirstName.ToLower().Contains(query.SearchPhrase.ToLower())|| e.LastName.ToLower().Contains(query.SearchPhrase.ToLower())))
                .ToListAsync(cancellationToken);

            int totalCount = employees.Count();

            var paginatedResult = employees.Skip((query.PageNumber-1)*query.PageSize).Take(query.PageSize).ToList();

            var employeesDtos = _mapper.Map<List<EmployeeDto>>(paginatedResult);

            var result = new PagedResult<EmployeeDto>(employeesDtos, totalCount, query.PageSize,query.PageNumber);
            return result;
        }

        public async Task<int> CreateEmployee(CreateEmployeeDto employeeDto, CancellationToken cancellationToken)
        {
            
            var newEmployee = _mapper.Map<Employee>(employeeDto);
            
            var hashedPassword =_passwordHasher.HashPassword(newEmployee, employeeDto.Password);
            newEmployee.Password = hashedPassword;

            await _context.Employees.AddAsync(newEmployee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return newEmployee.Id;
        }

        public async Task DeleteEmployeeById(int id, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            if (employee is null)
                throw new NotFoundException("Employee not found");
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateEmployee(int id, UpdateEmployeeDto dto, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            if (employee is null) 
                throw new NotFoundException("Employee not found");
            employee.Email = dto.Email;
            employee.Position = dto.Position;
            employee.Status = dto.Status;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
