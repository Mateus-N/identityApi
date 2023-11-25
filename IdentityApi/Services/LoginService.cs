using IdentityApi.Dtos;
using IdentityApi.MarkupInterfaces;
using IdentityApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Services;

public class LoginService : ILoginService, IInjectable
{
    private readonly SignInManager<IdentityUser<Guid>> signInManager;
    private readonly IUsuarioService usuarioService;
    private readonly ITokenService tokenService;

    public LoginService(
        SignInManager<IdentityUser<Guid>> signInManager,
        IUsuarioService usuarioService,
        ITokenService tokenService)
    {
        this.signInManager = signInManager;
        this.usuarioService = usuarioService;
        this.tokenService = tokenService;
    }

    public async Task<TokenModel?> LogaUsuario(LoginRequest request)
    {
        IdentityUser<Guid>? user = usuarioService.BuscaUsuario(request.UserName);
        if (user != null)
        {
            SignInResult identityResult = await signInManager
                .PasswordSignInAsync(user.UserName!, request.Password, false, false);
            if (identityResult.Succeeded)
            {
                return tokenService.CreateToken(user);
            }
        }
        return null;
    }
}
