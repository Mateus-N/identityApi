using IdentityApi.Dtos;
using IdentityApi.MarkupInterfaces;
using IdentityApi.Models;
using IdentityApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Services;

public class IdentityRegisterService : IIdentityRegisterService, IInjectable
{
    private readonly UserManager<IdentityUser<Guid>> userManager;

    public IdentityRegisterService(UserManager<IdentityUser<Guid>> userManager)
    {
        this.userManager = userManager;
    }

    public async Task<RegisterErrors?> Register(IdentityUser<Guid> identityUser, CreateUserModelDto createDto)
    {
        IdentityResult result = await userManager.CreateAsync(identityUser, createDto.Password);
        if (result.Succeeded) return null;
        List<string> errors = result.Errors.Select(error => error.Code).ToList();
        return new RegisterErrors(errors);
    }
}