using System.ComponentModel.DataAnnotations;
using System.Data;
using EntityFrameworkCore.Triggers;
namespace EmployeeWebAPI.Models;
public class Employee
{
    [Key]
    public int EmpId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? Mobile { get; set; }
    public DateTime JoiningDate { get; set; }
    public int RoleId { get; set; }
    public int ManagerId { get; set; }
    public virtual Role Role { get; set; }
    public virtual Manager Manager { get; set; }
    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
}
