using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Data.DTOs;
public class EmployeeUpdateDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;

    [RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Invalid mobile number")]
    public string? Mobile { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
    public DateTime JoiningDate { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Role ID must be a positive integer")]
    public int RoleId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Role ID must be a positive integer")]
    public int ManagerId { get; set; }
}
