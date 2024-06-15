namespace EmployeeWebAPI.Data.DTOs;
public class EmployeeDTO
{
    public int EmpId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? Mobile { get; set; }
    public DateTime JoiningDate { get; set; }
}
