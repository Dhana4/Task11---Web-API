using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWebAPI.Data.DTOs;
namespace EmployeeWebAPI.Service.Interfaces;
public interface IEmployeeManager
{
    Task<bool> AddEmployee(EmployeeADDDTO employee);
    Task<IList<EmployeeDetails>> GetAllEmployees(string? orderBy, string? filter, string? filterValue,int? pageNumber,int? pageSize);
    Task<EmployeeDetails?> GetEmployeeById(int empId);
    Task<bool> UpdateEmployee(EmployeeUpdateDTO employee, int employeeId);
    Task<bool> DeleteEmployee(int empId);
    Task<IList<EmployeeDTO>> GetEmployeesByRoleId(int roleId);
    Task<bool> IsEmployeeExists(int empId);
    Task<EmployeeUpdateDTO?> GetEmployeeByIdForPartialUpdate(int empId);
}
