using EmployeeWebAPI.Interfaces;
using EmployeeWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeWebAPI.Data;
namespace EmployeeWebAPI.Repository;
public class UserRepository : IUserRepository
{
    private readonly EmployeeDbContext _dbContext;
    public UserRepository(EmployeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> AddUser(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IList<User>> GetAll()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User?> GetUserByUserName(string userName)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.UserName == userName);
    }
}
