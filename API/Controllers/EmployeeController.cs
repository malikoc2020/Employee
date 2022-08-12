using Business.Abstract;
using Business.DTO;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult> GetAll()
        {
            return Ok(await employeeService.GetAllEmployeesAsync());
        }


        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Get/{id:int}")]
        public async Task<ActionResult> Get([FromRoute] int id)
        {
            return Ok(await employeeService.GetEmployeeAsync(id));
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Add")]
        public async Task<ActionResult> Add(EmployeeDTO employeeDTO)
        {
            return Ok(await employeeService.AddEmployeeAsync(employeeDTO));
        }


        [HttpPatch]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("Update/{id:int}")]
        public async Task<ActionResult> Update([FromRoute] int id, EmployeeDTO employeeDTO)
        {
            return Ok(await employeeService.UpdateEmployeeAsync(id, employeeDTO));
        }


        [HttpPatch]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("SoftDelete/{id:int}")]
        public async Task<ActionResult> SoftDelete(int id, EmployeeDTO employeeDTO)
        {
            return Ok(await employeeService.SoftDeleteEmployeeAsync(id, employeeDTO));
        }


        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("HardDelete")]
        public async Task<ActionResult> HardDelete(int id)
        {
            return Ok(await employeeService.HardDeleteEmployeeAsync(id));
        }
    }
}
