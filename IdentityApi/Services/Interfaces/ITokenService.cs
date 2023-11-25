using IdentityApi.Dtos;
using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Services.Interfaces
{
    public interface ITokenService
    {
        TokenModel CreateToken(IdentityUser<Guid> usuario);
    }
}