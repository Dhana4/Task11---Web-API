using AutoMapper;
using EmployeeWebAPI.Data.DTOs;
using EmployeeWebAPI.Interfaces;
using EmployeeWebAPI.Models;
using EmployeeWebAPI.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EmployeeWebAPI.Service.Managers;
public class EmployeeManager : IEmployeeManager
{
    private readonly IEmployeeRepository employeeDataAccess;
    private readonly IMapper mapper;
    public EmployeeManager(IEmployeeRepository employeeDataAccess, IMapper mapper)
    {
        this.employeeDataAccess = employeeDataAccess;
        this.mapper = mapper;
    }

    public async Task<bool> AddEmployee(EmployeeADDDTO employeeDTO)
    {
        Employee employee = mapper.Map<Employee>(employeeDTO);
        return await employeeDataAccess.AddEmployee(employee);
    }

    public async Task<IList<EmployeeDetails>> GetAllEmployees(string? orderBy, string? filter, string? filterValue, int? pageNumber,int? pageSize)
    {
        Expression<Func<Employee, bool>>? filterExpression = BuildFilterExpression(filter, filterValue);
        Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? orderByExpression = BuildOrderByExpression(orderBy);
        return mapper.Map<IList<EmployeeDetails>>(await employeeDataAccess.GetAllEmployees(filterExpression, orderByExpression, pageNumber, pageSize));
    }

    public async Task<EmployeeDetails?> GetEmployeeById(int empId)
    {
        Employee employee = await employeeDataAccess.GetEmployeeById(empId);
        return mapper.Map<EmployeeDetails>(employee);
    }
    public async Task<EmployeeUpdateDTO?> GetEmployeeByIdForPartialUpdate(int empId)
    {
        Employee employee = await employeeDataAccess.GetEmployeeById(empId);
        return mapper.Map<EmployeeUpdateDTO>(employee);
    }
    public async Task<bool> UpdateEmployee(EmployeeUpdateDTO employeeDTO, int employeeId)
    {
        Employee employee = mapper.Map<Employee>(employeeDTO);
        employee.EmpId = employeeId;
        return await employeeDataAccess.UpdateEmployee(employee);
    }

    public async Task<bool> DeleteEmployee(int empId)
    {
       return await employeeDataAccess.DeleteEmployee(empId);
    }

    public async Task<IList<EmployeeDTO>> GetEmployeesByRoleId(int roleId)
    {
        IList<Employee> employees = await employeeDataAccess.GetEmployeesByRoleId(roleId);
        return mapper.Map<List<EmployeeDTO>>(employees);
    }
    public async Task<bool> IsEmployeeExists(int empId)
    {
        return await employeeDataAccess.IsEmployeeExists(empId);
    }

    private Expression<Func<Employee, bool>>? BuildFilterExpression(string? filter, string? filterValue)
    {
        if (string.IsNullOrEmpty(filter) || string.IsNullOrEmpty(filterValue))
        {
            return null;
        }
        return filter switch
        {
            "Name" => e => EF.Functions.Like(e.FirstName + " " + e.LastName, $"%{filterValue}%"),
            "Location" => e => e.Role.Location.LocationName.Contains(filterValue),
            "Department" => e => e.Role.Department.DepartmentName.Contains(filterValue),
            "RoleName" => e => e.Role.RoleName.Contains(filterValue),
            "ManagerName" => e => e.Manager.ManagerName.Contains(filterValue),
            _ => null
        };
    }

    private Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? BuildOrderByExpression(string? orderBy)
    {
        return orderBy switch
        {
            "FirstName" => q => q.OrderBy(e => e.FirstName),
            "LastName" => q => q.OrderBy(e => e.LastName),
            "DateOfBirth" => q => q.OrderBy(e => e.DateOfBirth),
            "JoiningDate" => q => q.OrderBy(e => e.JoiningDate),
            _ => q => q.OrderBy(e => e.EmpId)
        };
    }
}