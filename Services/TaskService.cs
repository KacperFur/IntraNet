
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

        public async Task<int> CreateTask(CreateEmployeeTaskDto dto, CancellationToken cancellationToken)
        {
            var employeeTask = _mapper.Map<EmployeeTask>(dto);

            await _context.Tasks.AddAsync(employeeTask, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return employeeTask.Id;
        }

        public async Task DeleteTask(int id, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
            if( task is null)
            {
                throw new NotFoundException("Task not found");
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync(cancellationToken);

        }

        public async Task<PagedResult<EmployeeTaskDto>> GetAll(EmployeeTaskQuery query, CancellationToken cancellationToken)
        {
            var tasks = await _context.Tasks.AsNoTracking().ToListAsync(cancellationToken);
            var totalCount = tasks.Count;
            
            
            var paginatedTask = tasks.Where(e=>query.Tag==null || e.Tag.Contains(query.Tag)).Skip((query.PageNumber-1)*query.PageSize).Take(query.PageSize);
            var taskDtos = _mapper.Map<List<EmployeeTaskDto>>(paginatedTask);
            var results = new PagedResult<EmployeeTaskDto>(taskDtos,totalCount,query.PageSize,query.PageNumber);
            return results;
        }

        public async Task<List<EmployeeTaskDto>> GetByEmployeeId(int id, CancellationToken cancellationToken)
        {
            var tasks = await _context.Tasks.AsNoTracking().Where(t => t.AssignedEmployeeId == id).ToListAsync(cancellationToken);
            if (tasks is null)
            {
                throw new NotFoundException("No tasks found");
            }
            var results = _mapper.Map<List<EmployeeTaskDto>>(tasks);
            return results;
        }

        public async Task UpdateTask(UpdateEmployeeTaskDto dto, int id, CancellationToken cancellationToken)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
            if (task is null) { throw new NotFoundException("Task not found"); }

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.StartDate = dto.StartDate;
            task.FinishDate = dto.FinishDate;
            task.AssignedEmployeeId = dto.AssignedEmployeeId;
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
