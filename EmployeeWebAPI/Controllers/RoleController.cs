using Microsoft.AspNetCore.Mvc;
using EmployeeWebAPI.Data.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using EmployeeWebAPI.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
namespace EmployeeWebAPI.Controllers;
[Route("api/[Controller]")]
[ApiController]
public class RoleController : Controller
{
    private readonly IRoleManager roleManager;
    public RoleController(IRoleManager roleManager)
    {
        this.roleManager = roleManager;
    }
    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        IList<RoleDetails> roleDTOs = await roleManager.GetAllRoles();
        if(roleDTOs.Count == 0)
        {
            return NotFound("No roles found");
        }
        return Ok(roleDTOs);
    }
    [Authorize]
    [HttpGet("{roleId}")]
    public async Task<IActionResult> GetRoleById(int roleId)
    {
        if (!await roleManager.IsRoleIdValid(roleId))
        {
            return BadRequest("Invalid Role Id");
        }
        return Ok(roleManager.GetRoleById(roleId));
    }
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddRole(RoleDTO roleDTO)
    {
        bool IsRoleAdded = await roleManager.AddRole(roleDTO);
        if (!IsRoleAdded)
        {
            return BadRequest("Failed to add Role");
        }
        return Ok("Role added successfully!");
    }
    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateRole(int roleId, RoleDTO role)
    {
        if (!await roleManager.IsRoleIdValid(roleId))
        {
            return NotFound("Role Not Found");
        }
        bool isRoleUpdated = await roleManager.EditRole(role, roleId);
        if (!isRoleUpdated)
        {
            return BadRequest("Failed to update Role");
        }
        return Ok("Role updated successfully!");
    }
    [Authorize]
    [HttpPatch]
    public async Task<IActionResult> UpdateRolePartially(int roleId, JsonPatchDocument<RoleDTO> patchDocument)
    {
        if (!await roleManager.IsRoleIdValid(roleId))
        {
            return NotFound("Role Not Found");
        }
        RoleDTO existingRole = await roleManager.GetRoleByIdForPartialUpdate(roleId);
        patchDocument.ApplyTo(existingRole);
        bool isRoleUpdated = await roleManager.EditRole(existingRole, roleId);
        if (!isRoleUpdated)
        {
            return BadRequest("Failed to update Role");
        }
        return Ok("Role updated successfully!");
    }
}
