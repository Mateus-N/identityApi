using IdentityApi.MarkupInterfaces;
using IdentityApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Services;

public class UsuarioService : IUsuarioService, IInjectable
{
    private readonly UserManager<IdentityUser<Guid>> userManager;

    public UsuarioService(UserManager<IdentityUser<Guid>> userManager)
    {
        this.userManager = userManager;
    }

    public IdentityUser<Guid>? BuscaUsuario(string username)
    {
        return userManager.Users.FirstOrDefault(u =>
            u.NormalizedUserName == username.ToUpper() ||
            u.NormalizedEmail == username.ToUpper());
    }
}
