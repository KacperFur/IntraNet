
using AutoMapper;
using IntraNet.Entities;
using IntraNet.Exceptions;
using IntraNet.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Sources;

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

        public async Task<PagedResult<EmployeeTaskDto>> GetAll(EmployeeTaskQuery query )
        {
            var tasks = await _context.Tasks.AsNoTracking().ToListAsync();
            var totalCount = tasks.Count;
            
            
            var paginatedTask = tasks.Where(e=>query.Tag==null || e.Tag.Contains(query.Tag)).Skip((query.PageNumber-1)*query.PageSize).Take(query.PageSize);
            var taskDtos = _mapper.Map<List<EmployeeTaskDto>>(paginatedTask);
            var results = new PagedResult<EmployeeTaskDto>(taskDtos,totalCount,query.PageSize,query.PageNumber);
            return results;
        }

        public async Task<List<EmployeeTaskDto>> GetByEmployeeId(int id)
        {
            var tasks = await _context.Tasks.AsNoTracking().Where(t => t.AssignedEmployeeId == id).ToListAsync();
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
            if (task is null) { throw new NotFoundException("Task not found"); }

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.StartDate = dto.StartDate;
            task.FinishDate = dto.FinishDate;
            task.AssignedEmployeeId = dto.AssignedEmployeeId;
            await _context.SaveChangesAsync();
        }
    }
}
