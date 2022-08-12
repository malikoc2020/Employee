using Business.DTO;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IJwtService
    {        
        Task<TokenDTO> Authenticate(LoginDTO user);
    }
}
