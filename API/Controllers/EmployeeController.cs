using Business.Abstract;
using Business.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            return new JsonResult(employeeService.GetAllEmployees());
        }
        [HttpGet]
        [Route("{id:int}")]
        public JsonResult Get([FromRoute] int id)
        {
            return new JsonResult(employeeService.GetEmployee(id));
        }

        [HttpPost]
        public ActionResult Add(EmployeeDTO employeeDTO)
        {            
            return Ok(employeeService.AddEmployee(employeeDTO));
        }

        [HttpPatch]
        [Route("{id:int}")]
        public ActionResult Update([FromRoute]int id, EmployeeDTO employeeDTO)
        {
            return Ok(employeeService.UpdateEmployee(id, employeeDTO));
        }

        [HttpPatch]
        [Route("{id:int}")]
        public ActionResult SoftDelete(int id, EmployeeDTO employeeDTO)
        {
            return Ok(employeeService.SoftDeleteEmployee(id, employeeDTO));
        }

        [HttpDelete]
        public ActionResult HardDelete(int id)
        {
            return Ok(employeeService.HardDeleteEmployee(id));
        }
    }
}
