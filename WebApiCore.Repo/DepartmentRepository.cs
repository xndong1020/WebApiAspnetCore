using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApiNetCore.Entities;

namespace WebApiNetCore.Repo
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments;
        }

        public Department Get(int id, string relatedEntity = "")
        {
            if (!string.IsNullOrEmpty(relatedEntity))
                return _context.Departments.Include(dept => dept.Employees).FirstOrDefault(dept => dept.Id == id);

            return _context.Departments.FirstOrDefault(dept => dept.Id == id);
        }

        public int Insert(Department department)
        {
            _context.Departments.Add(department);
            SaveChanges();
            return department.Id;
        }

        public void Update(Department department)
        {
            _context.Entry<Department>(department).State = EntityState.Modified;
            SaveChanges();
        }

        public void Delete(int id)
        {
            var department = _context.Departments.FirstOrDefault(dept => dept.Id == id);
            _context.Departments.Remove(department);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    }
}
