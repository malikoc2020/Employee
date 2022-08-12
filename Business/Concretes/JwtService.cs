using Business.Abstract;
using Business.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business.Concretes
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public JwtService(IConfiguration configuration, UserManager<User> userManager)
        {
            this._configuration = configuration;
            this._userManager = userManager;
        }
        public async Task<TokenDTO> Authenticate(LoginDTO user)
        {
            var entityUser = await _userManager.FindByEmailAsync(user.Email);
            if (entityUser == null)
            {
                return null;
            }
            /*Check User email and password!*/
            if (!await _userManager.CheckPasswordAsync(entityUser, user.Password))
            {
                return null;
            }

            // we generate JSON Web Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, user.Email)
              }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDTO
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
