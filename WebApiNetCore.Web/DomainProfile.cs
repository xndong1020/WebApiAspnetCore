using AutoMapper;
using System.Collections.Generic;
using WebApiNetCore.Entities;
using WebApiNetCore.Web.Dtos;

namespace WebApiNetCore.Web
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMap<DepartmentDto, Department>();
            CreateMap<IEnumerable<DepartmentDto>, IEnumerable<Department>>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<IEnumerable<EmployeeDto>, IEnumerable<Employee>>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
