using EmployeeWebAPI.Data;
using EmployeeWebAPI.Models;
using EmployeeWebAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace EmployeeWebAPI.Repository;
public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeeDbContext dbContext;
    public EmployeeRepository(EmployeeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> AddEmployee(Employee employee)
    {
        await dbContext.Employees.AddAsync(employee);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEmployee(int empId)
    {
        var employeeToDelete = await dbContext.Employees.FindAsync(empId);
        if (employeeToDelete != null)
        {
            dbContext.Employees.Remove(employeeToDelete);
            await dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<IList<Employee>> GetAllEmployees(Expression<Func<Employee, bool>>? filter = null,
        Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? orderBy = null,
        int? pageNumber = null,
        int? pageSize = null)
    {
        IQueryable<Employee> query = dbContext.Employees;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        if (orderBy != null)
        {
            query = orderBy(query);
        }

        if (pageNumber.HasValue && pageSize.HasValue)
        {
            query = ApplyPagination(query, pageNumber.Value, pageSize.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<Employee> GetEmployeeById(int empId)
    {
        return await dbContext.Employees.SingleAsync(e => e.EmpId == empId);
    }

    public async Task<IList<Employee>> GetEmployeesByRoleId(int roleId)
    {
        return await dbContext.Employees.Where(e => e.RoleId == roleId).ToListAsync();
    }

    public async Task<bool> IsEmployeeExists(int empId)
    {
        return (await (dbContext.Employees.CountAsync(e => e.EmpId == empId))) == 1;
    }

    public async Task<bool> UpdateEmployee(Employee employee)
    {
        var existingEmployee = await dbContext.Employees.FindAsync(employee.EmpId);
        if (existingEmployee != null)
        {
            dbContext.Entry(existingEmployee).State = EntityState.Detached;
            dbContext.Employees.Update(employee);
            await dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    private IQueryable<Employee> ApplyPagination(IQueryable<Employee> query, int pageNumber, int pageSize)
    {
        int currentPageNumber = pageNumber;
        int currentPageSize = pageSize;
        return query.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize);
    }
}
