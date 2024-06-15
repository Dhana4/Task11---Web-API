using EmployeeWebAPI.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeWebAPI.Service.Interfaces;
public interface IRoleManager
{
    Task<IList<RoleDetails>> GetAllRoles();
    Task<bool> AddRole(RoleDTO role);
    Task<RoleDetails> GetRoleById(int roleId);
    Task<bool> EditRole(RoleDTO updatedRole, int roleId);
    Task<bool> IsRoleIdValid(int roleId);
    Task<RoleDTO> GetRoleByIdForPartialUpdate(int roleId);
}
