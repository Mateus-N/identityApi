using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Services.Interfaces
{
    public interface IUsuarioService
    {
        IdentityUser<Guid>? BuscaUsuario(string username);
    }
}