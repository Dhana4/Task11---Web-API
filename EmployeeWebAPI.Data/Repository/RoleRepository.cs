using EmployeeWebAPI.Data;
using EmployeeWebAPI.Interfaces;
using EmployeeWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPI.Repository;
public class RoleRepository : IRoleRepository
{
    private readonly EmployeeDbContext dbContext;
    public RoleRepository(EmployeeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public async Task<bool> AddRole(Role role)
    {
        await dbContext.Roles.AddAsync(role);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> EditRole(Role updatedRole)
    {
        Role existingRole = await dbContext.Roles.FindAsync(updatedRole.RoleId);
        if (existingRole != null)
        {
            dbContext.Entry(existingRole).State = EntityState.Detached;
            dbContext.Roles.Update(updatedRole);
            await dbContext.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<IList<Role>> GetAllRoles()
    {
        return await dbContext.Roles.ToListAsync();
    }

    public async Task<Role> GetRoleById(int roleId)
    {
        return await dbContext.Roles.FindAsync(roleId);
    }

    public async Task<bool> IsRoleIdValid(int roleId)
    {
        return await dbContext.Roles.AnyAsync(r => r.RoleId == roleId);
    }
}
