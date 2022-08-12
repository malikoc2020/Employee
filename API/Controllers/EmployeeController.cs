using Business.Abstract;
using Business.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]   
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService employeeService;
        public EmployeeController(IEmployeeService _employeeService)
        {
            employeeService = _employeeService;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("GetAll")]
        public JsonResult GetAll()
        {
            return new JsonResult(employeeService.GetAllEmployees());
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Get/{id:int}")]
        public JsonResult Get([FromRoute] int id)
        {
            return new JsonResult(employeeService.GetEmployee(id));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Add")]
        public ActionResult Add(EmployeeDTO employeeDTO)
        {            
            return Ok(employeeService.AddEmployee(employeeDTO));
        }

        [HttpPatch]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Update/{id:int}")]
        public ActionResult Update([FromRoute]int id, EmployeeDTO employeeDTO)
        {
            return Ok(employeeService.UpdateEmployee(id, employeeDTO));
        }

        [HttpPatch]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("SoftDelete/{id:int}")]
        public ActionResult SoftDelete(int id, EmployeeDTO employeeDTO)
        {
            return Ok(employeeService.SoftDeleteEmployee(id, employeeDTO));
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("HardDelete")]
        public ActionResult HardDelete(int id)
        {
            return Ok(employeeService.HardDeleteEmployee(id));
        }
    }
}
