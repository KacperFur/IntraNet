using IntraNet.Entities;
using IntraNet.Models;

namespace IntraNet.Services
{
    public interface ITaskService
    {
        Task<List<EmployeeTaskDto>> GetAll();
        Task<int> CreateTask(CreateEmployeeTaskDto dto);
        Task DeleteTask(int id);
        Task<List<EmployeeTaskDto>> GetByEmployeeId(int id);
        Task UpdateTask(UpdateEmployeeTaskDto dto, int id);
    }
}
