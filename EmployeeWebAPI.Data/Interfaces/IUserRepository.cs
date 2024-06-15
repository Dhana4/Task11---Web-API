using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWebAPI.Models;
namespace EmployeeWebAPI.Interfaces;
public interface IUserRepository
{
    Task<IList<User>> GetAll();
    Task<User?> GetUserByUserName(string userName);
    Task<bool> AddUser(User user);
}
