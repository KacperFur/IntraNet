using IntraNet.Models;

namespace IntraNet.Services
{
    public interface IEmployeeService
    {
        Task<int> CreateEmployee(CreateEmployeeDto employeeDto, CancellationToken cancellationToken);
        Task<PagedResult<EmployeeDto>> GetAll(EmployeeQuery query, CancellationToken cancellationToken);
        Task<EmployeeDto> GetById(int id, CancellationToken cancellationToken);
        Task DeleteEmployeeById(int id, CancellationToken cancellationToken);
        Task UpdateEmployee(int id, UpdateEmployeeDto dto, CancellationToken cancellationToken);
    }
}