using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Models;
public class Role
{
    [Key]
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public int DepartmentId { get; set; }
    public string? Description { get; set; }
    public int LocationId { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }
    public virtual Location Location { get; set; }
    public virtual Department Department { get; set; }
}
