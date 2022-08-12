using Business.DTO;
using Domain.Entities;

namespace Business.Abstract
{
    public interface IEmployeeService
    {
        IQueryable<Employee> EmployeesAsQueryable();
        ReturnObjectDTO GetEmployee(int id);
        Task<ReturnObjectDTO> GetEmployeeAsync(int id);
        ReturnObjectDTO GetAllEmployees();
        Task<ReturnObjectDTO> GetAllEmployeesAsync();
        ReturnObjectDTO AddEmployee(EmployeeDTO employee);
        Task<ReturnObjectDTO> AddEmployeeAsync(EmployeeDTO employee);
        ReturnObjectDTO UpdateEmployee(int id, EmployeeDTO employee, string updatedBy = "");
        Task<ReturnObjectDTO> UpdateEmployeeAsync(int id, EmployeeDTO employee, string updatedBy = "");
        ReturnObjectDTO SoftDeleteEmployee(int id, EmployeeDTO employee, string updatedBy = "");
        Task<ReturnObjectDTO> SoftDeleteEmployeeAsync(int id, EmployeeDTO employee, string updatedBy = "");
        ReturnObjectDTO HardDeleteEmployee(int id, string updatedBy = "");
        Task<ReturnObjectDTO> HardDeleteEmployeeAsync(int id, string updatedBy = "");
    }
}
