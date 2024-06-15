using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeWebAPI.Models;
public class UserDTOToLogin
{
    [Required(ErrorMessage = "User name is required")]
    [EmailAddress(ErrorMessage = "User Name must be a valid email address")]
    public string UserName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
}
