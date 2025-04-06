using IntraNet.Models;

namespace IntraNet.Services
{
    public interface IEmployeeService
    {
        Task<int> CreateEmployee(CreateEmployeeDto employeeDto);
        Task<PagedResult<EmployeeDto>> GetAll(EmployeeQuery query);
        Task<EmployeeDto> GetById(int id);
        Task DeleteEmployeeById(int id);
        Task UpdateEmployee(int id, UpdateEmployeeDto dto);
    }
}