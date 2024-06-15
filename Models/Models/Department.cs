using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Models;
public class Department
{
    [Key]
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    public virtual ICollection<Role> Roles { get; set; }
}
