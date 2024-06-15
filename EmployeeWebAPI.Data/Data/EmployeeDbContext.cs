using Microsoft.EntityFrameworkCore;
using EmployeeWebAPI.Models;
using EntityFrameworkCore.Triggers;
namespace EmployeeWebAPI.Data;
public class EmployeeDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeProject> EmployeeProjects { get; set; }
    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().ToTable("Employees", tb => tb.HasTrigger("trgAfterInsert"));
        modelBuilder.Entity<Employee>().ToTable("Employees", tb => tb.HasTrigger("trgAfterUpdate"));
        modelBuilder.Entity<Employee>().ToTable("Employees", tb => tb.HasTrigger("trgAfterDelete"));
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Role)
            .WithMany(r => r.Employees)
            .HasForeignKey(e => e.RoleId);
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Manager)
            .WithMany(m => m.Employees)
            .HasForeignKey(e => e.ManagerId);
        modelBuilder.Entity<EmployeeProject>()
            .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });
        modelBuilder.Entity<EmployeeProject>()
            .HasOne(ep => ep.Employee)
            .WithMany(e => e.EmployeeProjects)
            .HasForeignKey(ep => ep.EmployeeId);
        modelBuilder.Entity<EmployeeProject>()
            .HasOne(ep => ep.Project)
            .WithMany(p => p.EmployeeProjects)
            .HasForeignKey(ep => ep.ProjectId);
        modelBuilder.Entity<Role>()
            .HasOne(r => r.Location)
            .WithMany(l => l.Roles)
            .HasForeignKey(r => r.LocationId);
        modelBuilder.Entity<Role>()
            .HasOne(r => r.Department)
            .WithMany(d => d.Roles)
            .HasForeignKey(r => r.DepartmentId);
        modelBuilder.Entity<Location>().HasData(
                new Location { LocationId = 1, LocationName = "Hyd" },
                new Location { LocationId = 2, LocationName = "Benglore" }
            );
        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentId = 1, DepartmentName = "PE" },
            new Department { DepartmentId = 2, DepartmentName = "QA" }
            );
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, RoleName = "Developer", Description = "PE desc", DepartmentId = 1, LocationId = 2},
            new Role { RoleId = 2, RoleName = "Quality Analyst", Description = "QA desc", DepartmentId = 2, LocationId = 1 }
            );
        modelBuilder.Entity<Manager>().HasData(
            new Manager { ManagerId = 1, ManagerName = "Manager1"},
            new Manager { ManagerId = 2, ManagerName = "Manager2" }
            );
        modelBuilder.Entity<Project>().HasData(
            new Project { ProjectId = 1, ProjectName = "A"},
            new Project { ProjectId = 2, ProjectName = "B"}
            );
        modelBuilder.Entity<Employee>().HasData(
            new Employee { EmpId = 1, FirstName = "Renu", Email = "renu@gmail.com", JoiningDate = DateTime.Now, RoleId = 1, ManagerId = 2},
            new Employee { EmpId = 2, FirstName = "Vinay", Email = "Vinay@gmail.com", JoiningDate = DateTime.Now, RoleId = 2, ManagerId = 1 }
            );
        modelBuilder.Entity<EmployeeProject>().HasData(
            new EmployeeProject { EmployeeId = 1 , ProjectId = 1},
            new EmployeeProject { EmployeeId = 1, ProjectId = 2},
            new EmployeeProject { EmployeeId = 2, ProjectId = 2}
            );
    }
}
