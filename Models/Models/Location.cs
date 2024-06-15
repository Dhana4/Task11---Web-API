using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Models;
public class Location
{
    [Key]
    public int LocationId { get; set; }
    public string LocationName { get; set; } = string.Empty;
    public virtual ICollection<Role> Roles { get; set; }
}
