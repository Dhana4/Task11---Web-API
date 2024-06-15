using AutoMapper;
using EmployeeWebAPI.Interfaces;
using EmployeeWebAPI.Models;
using EmployeeWebAPI.Service.DTOs;
using EmployeeWebAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Service.Managers;
public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserManager(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<bool> AddUser(UserDTOToRegister userDTO)
    {
        return await _userRepository.AddUser(_mapper.Map<User>(userDTO));
    }

    public async Task<IList<UserDTOToLogin>> GetAll()
    {
        return _mapper.Map<IList<UserDTOToLogin>>(await _userRepository.GetAll());
    }

    public async Task<UserDTOToRegister> GetUserByUserName(string userName)
    {
        return _mapper.Map<UserDTOToRegister>(await _userRepository.GetUserByUserName(userName));
    }
}
