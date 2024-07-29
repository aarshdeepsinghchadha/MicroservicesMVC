using Mango.Services.Web.Models;
using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDto> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto> RegisterAsync(RegisterationRequestDto registerationRequestDto);
        Task<ResponseDto> AssignRoleAsync(RegisterationRequestDto registerationRequestDto);
    }
}
