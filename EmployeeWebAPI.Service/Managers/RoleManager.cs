using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeWebAPI.Data.DTOs;
using EmployeeWebAPI.Interfaces;
using EmployeeWebAPI.Models;
using EmployeeWebAPI.Service.Interfaces;
namespace EmployeeWebAPI.Service.Managers;
public class RoleManager : IRoleManager
{
    private readonly IRoleRepository roleRepository;
    private readonly IMapper mapper;

    public RoleManager(IRoleRepository roleRepository, IMapper mapper)
    {
        this.roleRepository = roleRepository;
        this.mapper = mapper;
    }
    public async Task<IList<RoleDetails>> GetAllRoles()
    {
        IList<Role> roles = await roleRepository.GetAllRoles();
        return mapper.Map<List<RoleDetails>>(roles);
    }
    public async Task<bool> AddRole(RoleDTO roleDTO)
    {
        Role role = mapper.Map<Role>(roleDTO);
        return await roleRepository.AddRole(role);
    }
    public async Task<RoleDetails> GetRoleById(int roleId)
    {
        Role role = await roleRepository.GetRoleById(roleId);
        return mapper.Map<RoleDetails>(role);
    }
    public async Task<RoleDTO> GetRoleByIdForPartialUpdate(int roleId)
    {
        Role role = await roleRepository.GetRoleById(roleId);
        return mapper.Map<RoleDTO>(role);
    }
    public async Task<bool> EditRole(RoleDTO updatedRole, int roleId)
    {
        Role role = mapper.Map<Role>(updatedRole);
        role.RoleId = roleId;
        return await roleRepository.EditRole(role);
    }
    public async Task<bool> IsRoleIdValid(int roleId)
    {
        return await roleRepository.IsRoleIdValid(roleId);
    }
}
