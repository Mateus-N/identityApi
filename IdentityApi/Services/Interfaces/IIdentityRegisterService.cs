using IdentityApi.Dtos;
using IdentityApi.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Services.Interfaces;

public interface IIdentityRegisterService
{
    Task<RegisterErrors?> Register(IdentityUser<Guid> identityUser, CreateUserModelDto createDto);
}