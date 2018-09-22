using Microsoft.EntityFrameworkCore;
using WebApiNetCore.Entities;

namespace WebApiNetCore.Repo
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 将Employee entity class map 到 tblEmployee 表
            modelBuilder.Entity<Employee>().ToTable("tblEmployee");
            // Department entity class map 到 Department 表
            modelBuilder.Entity<Department>().ToTable("tblDepartment");

            // Entity Class Validation
            modelBuilder.Entity<Employee>().Property(t => t.Name).IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.Gender).IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.Salary).IsRequired();
            modelBuilder.Entity<Employee>().Property(t => t.DepartmentId).IsRequired();

            modelBuilder.Entity<Department>().Property(t => t.DepartmentName).IsRequired();
            modelBuilder.Entity<Department>().Property(t => t.DepartmentName).HasMaxLength(10);
            modelBuilder.Entity<Department>().Property(t => t.Location).IsRequired();
            modelBuilder.Entity<Department>().Property(t => t.DepartmentHead).IsRequired();

            // 设置导航属性，建立Department 和 Employee的一对多关系
            modelBuilder.Entity<Employee>()                         // 从Employee表开始，将Student作为左表，Department作为右表
                .HasOne<Department>(e => e.Department)         // 每个Employee都属于一个Department，这就要求每个Employee都必须有一个FK，指向Department
                .WithMany(d => d.Employees)                         // 在表关系的另外一端，也就是Department，每个Department都会有多个Employees
                .HasForeignKey(e => e.DepartmentId);
        }
    }
}
