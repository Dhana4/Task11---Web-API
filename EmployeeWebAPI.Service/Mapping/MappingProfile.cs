namespace EmployeeWebAPI.Mapping;
using AutoMapper;
using EmployeeWebAPI.Models;
using EmployeeWebAPI.Data.DTOs;
using EmployeeWebAPI.Service.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EmployeeDTO, Employee>();
        CreateMap<Employee, EmployeeDTO>();
        CreateMap<Employee, EmployeeDetails>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Role.Location.LocationName))
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Role.Department.DepartmentName))
            .ForMember(dest => dest.ManagerName, opt => opt.MapFrom(src => src.Manager.ManagerName))
            .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => src.EmployeeProjects.Select(ep => ep.Project.ProjectName)));
        CreateMap<EmployeeADDDTO, Employee>();
        CreateMap<EmployeeUpdateDTO, Employee>();
        CreateMap<Employee, EmployeeUpdateDTO>();
        CreateMap<RoleDTO, Role>();
        CreateMap<Role, RoleDTO>();
        CreateMap<Role, RoleDetails>()
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
            .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.LocationName));
        CreateMap<User, UserDTOToLogin>();
        CreateMap<UserDTOToLogin, User>();
        CreateMap<UserDTOToRegister, User>();
        CreateMap<User, UserDTOToRegister>();
    }
}
