using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeWebAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using EmployeeWebAPI.Service.Interfaces;
using BCrypt.Net;
using System.Security.Claims;
using EmployeeWebAPI.Service.DTOs;
namespace EmployeeWebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserManager _userManager;
    public AuthenticationController(IConfiguration configuration, IUserManager userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }
    private async Task<UserDTOToRegister?> AuthenticateUser(UserDTOToLogin user)
    {
        UserDTOToRegister _user = null;
        UserDTOToRegister? existingUser = await _userManager.GetUserByUserName(user.UserName);
        if(existingUser != null)
        {
            if(BCrypt.Net.BCrypt.Verify(user.Password, existingUser.Password))
            {
                _user = new UserDTOToRegister { UserName = existingUser.UserName , role = existingUser.role};
            }
        }
        return _user;
    }

    private async Task<string> GenerateToken(UserDTOToRegister user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
        new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) , new Claim("role", user.role) },
        expires: DateTime.Now.AddMinutes(10),
        signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserDTOToLogin user)
    {
        IActionResult response = Unauthorized();
        var _user = await AuthenticateUser(user);
        if (_user != null)
        {
            var token = await GenerateToken(_user);
            response = Ok(new { token = token });
        }
        return response;
    }
    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserDTOToRegister user)
    {
        if (await _userManager.GetUserByUserName(user.UserName) != null)
        {
            return BadRequest("User already exists.");
        }
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        await _userManager.AddUser(user);
        return Ok("User registered successfully.");
    }
}