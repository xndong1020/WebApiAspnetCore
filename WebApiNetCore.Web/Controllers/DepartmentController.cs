using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCore.Entities;
using WebApiNetCore.Services;
using WebApiNetCore.Web.Dtos;

namespace WebApiNetCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDto>> GetAll()
        {
            var departments =  _service.GetDepartments().ToList();
            var result = _mapper.Map<IEnumerable<DepartmentDto>>(departments).ToList();
            return result;
        }


        [HttpGet("{id}", Name = "GetDepartment")]
        public ActionResult<DepartmentDto> Get(int id)
        {
            var department = _service.GetDepartment(id, "Employees"); 
            return _mapper.Map<DepartmentDto>(department);
        }

        [HttpPost]
        public ActionResult Post(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            var id = _service.InsertDepartment(department);
            return Created("/api/Department/" + id, department);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto);
            _service.UpdateDepartment(department);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeleteDepartment(id);
            return NoContent();
        }
    }
}