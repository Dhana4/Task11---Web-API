namespace EmployeeWebAPI.Data.DTOs;
using System.ComponentModel.DataAnnotations;
public class RoleDTO
{
    [Required(ErrorMessage = "Role Name is Required")]
    [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Role Name must contain only letters")]
    public string RoleName { get; set; }
    [Required(ErrorMessage = "Department Id is Required")]
    public int DepartmentId { get; set; }
    public string? Description { get; set; }

    [Required(ErrorMessage = "Department Id is Required")]
    public int LocationId { get; set; }
}
