using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiNetCore.Entities;
using WebApiNetCore.Services;

namespace WebApiNetCore.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetAll()
        {
            return _service.GetDepartments().ToList();
        }


        [HttpGet("{id}", Name = "GetDepartment")]
        public ActionResult<Department> Get(int id)
        {
            return _service.GetDepartment(id, "Employees");
        }

        [HttpPost]
        public ActionResult Post(Department department)
        {
            var id = _service.InsertDepartment(department);
            return Created("/api/Department/" + id, department);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Department department)
        {
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