using IntraNet.Entities;
using IntraNet.Models;

namespace IntraNet.Services
{
    public interface ITaskService
    {
        Task<PagedResult<EmployeeTaskDto>> GetAll(EmployeeTaskQuery query);
        Task<int> CreateTask(CreateEmployeeTaskDto dto);
        Task DeleteTask(int id);
        Task<List<EmployeeTaskDto>> GetByEmployeeId(int id);
        Task UpdateTask(UpdateEmployeeTaskDto dto, int id);
    }
}
