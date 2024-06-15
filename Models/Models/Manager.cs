using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Models;
public class Manager
{
    [Key]
    public int ManagerId { get; set; }
    public string ManagerName { get; set; } = string.Empty;
    public virtual ICollection<Employee> Employees { get; set; }
}
