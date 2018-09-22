using System.Collections.Generic;

namespace WebApiNetCore.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public string DepartmentHead { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
