using EmployeeWebAPI.Models;

namespace EmployeeWebAPI.Interfaces;
public interface IRoleRepository
{
    Task<IList<Role>> GetAllRoles();
    Task<bool> AddRole(Role role);
    Task<Role> GetRoleById(int roleId);
    Task<bool> EditRole(Role updatedRole);
    Task<bool> IsRoleIdValid(int roleId);

}
