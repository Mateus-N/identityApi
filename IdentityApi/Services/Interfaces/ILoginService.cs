using IdentityApi.Dtos;

namespace IdentityApi.Services.Interfaces;

public interface ILoginService
{
    Task<TokenModel?> LogaUsuario(LoginRequest request);
}