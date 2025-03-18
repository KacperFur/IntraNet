using IntraNet.Models;

namespace IntraNet.Services
{
    public interface IEmployeeService
    {
        Task<int> CreateEmployee(CreateEmployeeDto employeeDto);
        Task<IEnumerable<EmployeeDto>> GetAll();
        Task<EmployeeDto> GetById(int id);
        Task DeleteEmployeeById(int id);
        Task UpdateEmployee(int id, UpdateEmployeeDto dto);
    }
}