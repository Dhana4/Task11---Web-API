using System.ComponentModel.DataAnnotations;

namespace EmployeeWebAPI.Models;
public class Project
{
    [Key]
    public int ProjectId { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
}
