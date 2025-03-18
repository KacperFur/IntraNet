
using AutoMapper;
using IntraNet.Entities;
using IntraNet.Exceptions;
using IntraNet.Models;
using Microsoft.EntityFrameworkCore;

namespace IntraNet.Services
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly IntraNetDbContext _context;

        public TaskService(IntraNetDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> CreateTask(CreateEmployeeTaskDto dto)
        {
            var employeeTask = _mapper.Map<EmployeeTask>(dto);

            await _context.Tasks.AddAsync(employeeTask);
            await _context.SaveChangesAsync();
            return employeeTask.Id;
        }

        public async Task DeleteTask(int id)
        {
            var Task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
            if( Task is null)
            {
                throw new NotFoundException("Task not found");
            }
            _context.Tasks.Remove(Task);
            await _context.SaveChangesAsync();

        }

        public async Task<List<EmployeeTaskDto>> GetAll()
        {
            var tasks = await _context.Tasks.ToListAsync();
            var results = _mapper.Map<List<EmployeeTaskDto>>(tasks);
            return results;
        }

        public async Task<List<EmployeeTaskDto>> GetByEmployeeId(int id)
        {
            var tasks = await _context.Tasks.Where(t => t.AssignedEmployeeId == id).ToListAsync();
            if (tasks is null)
            {
                throw new NotFoundException("No tasks found");
            }
            var results = _mapper.Map<List<EmployeeTaskDto>>(tasks);
            return results;
        }

        public async Task UpdateTask(UpdateEmployeeTaskDto dto, int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(e => e.Id == id);
            task.Title = dto.Title;
            task.Description = dto.Description;
            task.StartDate = dto.StartDate;
            task.FinishDate = dto.FinishDate;
            task.AssignedEmployeeId = dto.AssignedEmployeeId;
            await _context.SaveChangesAsync();
        }
    }
}
