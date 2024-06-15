using EmployeeWebAPI.Models;
using EmployeeWebAPI.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EmployeeWebAPI.Service.Interfaces;
public interface IUserManager
{
    Task<IList<UserDTOToLogin>> GetAll();
    Task<UserDTOToRegister> GetUserByUserName(string userName);
    Task<bool> AddUser(UserDTOToRegister userDTO);
}
