using IntraNet.Entities;
using IntraNet.Models;

namespace IntraNet.Services
{
    public interface ITaskService
    {
        Task<PagedResult<EmployeeTaskDto>> GetAll(EmployeeTaskQuery query, CancellationToken cancellationToken);
        Task<int> CreateTask(CreateEmployeeTaskDto dto, CancellationToken cancellationToken);
        Task DeleteTask(int id, CancellationToken cancellationToken);
        Task<List<EmployeeTaskDto>> GetByEmployeeId(int id, CancellationToken cancellationToken);
        Task UpdateTask(UpdateEmployeeTaskDto dto, int id, CancellationToken cancellationToken);
    }
}
