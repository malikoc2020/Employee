using Business.DTO;

namespace Business.Abstract
{
    public interface IJwtService
    {        
        Task<TokenDTO> Authenticate(LoginDTO user);
    }
}
