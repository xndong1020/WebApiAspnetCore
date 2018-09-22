using System.Collections.Generic;
using WebApiNetCore.Entities;
using WebApiNetCore.Repo;

namespace WebApiNetCore.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public Department GetDepartment(int id, string relatedEntity = "")
        {
            return _departmentRepository.Get(id, relatedEntity);
        }

        public int InsertDepartment(Department department)
        {
            return _departmentRepository.Insert(department);
        }

        public void UpdateDepartment(Department department)
        {
            _departmentRepository.Update(department);
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.Delete(id);
        }
    }
}
