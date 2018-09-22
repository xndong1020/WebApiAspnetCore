using System.Collections.Generic;

namespace WebApiNetCore.Web.Dtos
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Location { get; set; }
        public string DepartmentHead { get; set; }

        public List<EmployeeDto> Employees { get; set; }
    }
}
