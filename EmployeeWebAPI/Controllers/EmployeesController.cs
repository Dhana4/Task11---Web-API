using EmployeeWebAPI.Data.DTOs;
using EmployeeWebAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeWebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeesController : Controller
{
    private readonly IEmployeeManager employeeManager;
    public EmployeesController(IEmployeeManager employeeManager)
    {
        this.employeeManager = employeeManager;
    }
    [Authorize(Roles = "Admin,SuperAdmin,Employee")]
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<EmployeeDetails>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetAllEmployees(string? orderBy = null, string? filter = null, string? filterValue = null,int? pageNumber = null, int? pageSize = null)
    {
        var employees = await employeeManager.GetAllEmployees(orderBy, filter, filterValue, pageNumber,pageSize);
        if(employees.Count == 0)
        {
            return NotFound("No Employees Found");
        }
        return Ok(employees);
    }
    [Authorize]
    [HttpGet("empId")]
    [ProducesResponseType(200, Type = typeof(EmployeeDetails))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetEmployeeById(int empId)
    {
        if (await employeeManager.IsEmployeeExists(empId) == false)
        {
            return NotFound("Employee does not exist");
        }
        var empDTO = await employeeManager.GetEmployeeById(empId);
        return Ok(empDTO);
    }
    [Authorize]
    [HttpGet("roleId")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<EmployeeDTO>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetEmployeesByRoleId(int roleId)
    {
        var employees = await employeeManager.GetEmployeesByRoleId(roleId);
        if (employees.Count() == 0)
        {
            return NotFound("No Employee Found");
        }
        return Ok(employees);
    }
    [Authorize(Roles = "SuperAdmin")]
    [HttpDelete]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> DeleteEmployee(int employeeId)
    {
        bool IsEmployeeDeleted = await employeeManager.DeleteEmployee(employeeId);
        if (!IsEmployeeDeleted)
        {
            return NotFound("No Employee Found");
        }
        return Ok("Employee Deleted Successfully");
    }
    [Authorize(Roles = "SuperAdmin")]
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> AddEmployee(EmployeeADDDTO employeeToAdd)
    {
        bool IsEmpAdded = await employeeManager.AddEmployee(employeeToAdd);
        if (!IsEmpAdded)
        {
            return BadRequest("Failed to add employee.");
        }
        return Ok("Employee added successfully!");
    }
    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpPut]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateEmployee(int employeeId, [FromBody] EmployeeUpdateDTO employeeToUpdate)
    {
        if (! await employeeManager.IsEmployeeExists(employeeId))
        {
            return NotFound("Employee Not Found");
        }
        bool isEmployeeUpdated = await employeeManager.UpdateEmployee(employeeToUpdate,employeeId);
        if (!isEmployeeUpdated)
        {
            return BadRequest("Failed to update employee");
        }
        return Ok("Employee updated successfully!");
    }
    [Authorize(Roles = "Admin,SuperAdmin")]
    [HttpPatch]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> UpdateEmployeePartial(int employeeId, [FromBody] JsonPatchDocument<EmployeeUpdateDTO> patchDocument)
    {
        if (!await employeeManager.IsEmployeeExists(employeeId))
        {
            return NotFound("Employee Not Found");
        }
        EmployeeUpdateDTO existingEmployee = await employeeManager.GetEmployeeByIdForPartialUpdate(employeeId);
        patchDocument.ApplyTo(existingEmployee, ModelState);
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        bool isEmployeeUpdated = await employeeManager.UpdateEmployee(existingEmployee!, employeeId);
        if (!isEmployeeUpdated)
        {
            return BadRequest("Failed to update employee");
        }
        return Ok("Employee updated successfully!");
    }
}
