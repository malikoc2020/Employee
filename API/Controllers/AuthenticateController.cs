using API.Models.Requests;
using Business.Abstract;
using Business.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IJwtService jwtService;

        public AuthenticateController(IJwtService jwtService)
        {
            this.jwtService = jwtService;
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateModel model)
        {
            var token = await jwtService.Authenticate(
                new LoginDTO
                {
                    Email = model.Email,
                    Password = model.Password
                }
                );

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
