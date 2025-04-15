using IntraNet.Entities;
using IntraNet.Exceptions;
using IntraNet.Extensions;
using IntraNet.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks.Sources;

namespace IntraNet.Services
{
    public class TaskService : ITaskService
    {
        private readonly IntraNetDbContext _context;

        public TaskService(IntraNetDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTask(CreateEmployeeTaskDto dto, CancellationToken cancellationToken)
        {
            var EmployeeAssigned = await _context.Employees.FirstOrDefaultAsync(e => e.Id == dto.AssignedEmployeeId, cancellationToken);
            if (EmployeeAssigned == null)
            {
                throw new NotFoundException("Employee not found");
            }
            var employeeTask = dto.Adapt<EmployeeTask>();

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
            var tasks =_context.Tasks.AsNoTracking();
            var paginatedTask = await tasks.Paginate(query.PageNumber, query.PageSize).ToListAsync(cancellationToken);
            var totalCount = await tasks.CountAsync(cancellationToken);
        
            var taskDtos = paginatedTask.Adapt<List<EmployeeTaskDto>>();
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
            var results = tasks.Adapt<List<EmployeeTaskDto>>();
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
