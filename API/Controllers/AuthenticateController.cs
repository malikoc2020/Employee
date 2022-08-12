using API.Models.Requests;
using Business.Abstract;
using Business.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(AuthenticateModel model)
        {
            if (ModelState.IsValid)
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
            else
            {
                return BadRequest(string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage)));
            }
        }
    }
}
