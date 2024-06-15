using System.ComponentModel.DataAnnotations;
namespace EmployeeWebAPI.Data.DTOs;
public class EmployeeADDDTO
{
    [Required(ErrorMessage = "First name is required")]
    [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "First Name must contain only letters")]
    public string FirstName { get; set; }

    [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Last Name must contain only letters")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Joining date is required")]
    [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
    public DateTime JoiningDate { get; set; }

    [Required(ErrorMessage = "Role ID is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Role ID must be a positive integer")]
    public int RoleId { get; set; }

    [Required(ErrorMessage = "Manager ID is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Role ID must be a positive integer")]
    public int ManagerId { get; set; }

    [RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Invalid mobile number")]
    public string? Mobile { get; set; }

    [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
    public DateTime? DateOfBirth { get; set; }
}
