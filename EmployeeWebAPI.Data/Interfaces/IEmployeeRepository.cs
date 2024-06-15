using EmployeeWebAPI.Models;
using System.Linq.Expressions;
namespace EmployeeWebAPI.Interfaces;
public interface IEmployeeRepository
{
    Task<bool> AddEmployee(Employee employee);
    Task<bool> UpdateEmployee(Employee employee);
    Task<bool> DeleteEmployee(int empId);
    Task<IList<Employee>> GetAllEmployees(Expression<Func<Employee, bool>>? filter = null,
        Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? orderBy = null,
        int? pageNumber = null,
        int? pageSize = null);
    Task<Employee> GetEmployeeById(int empId);
    Task<IList<Employee>> GetEmployeesByRoleId(int roleId);
    Task<bool> IsEmployeeExists(int empId);
}
