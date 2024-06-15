namespace EmployeeWebAPI.Data.DTOs;
public class EmployeeDetails
{
    public int EmpId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? Mobile { get; set; }
    public DateTime JoiningDate { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string ManagerName { get; set; } = string.Empty;
    public ICollection<string> Projects { get; set; }
}
