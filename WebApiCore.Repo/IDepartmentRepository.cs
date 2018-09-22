using System.Collections.Generic;
using WebApiNetCore.Entities;

namespace WebApiNetCore.Repo
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetAll();
        Department Get(int id, string relatedEntity = "");
        int Insert(Department department);
        void Update(Department department);
        void Delete(int id);
        void SaveChanges();
    }
}
