using System.Collections.Generic;
using WebApiNetCore.Entities;

namespace WebApiNetCore.Services
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        Department GetDepartment(int id, string relatedEntity = "");
        int InsertDepartment(Department user);
        void UpdateDepartment(Department user);
        void DeleteDepartment(int id);
    }
}
