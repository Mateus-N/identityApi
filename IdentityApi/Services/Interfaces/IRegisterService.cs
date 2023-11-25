using IdentityApi.Dtos;
using IdentityApi.Models;

namespace IdentityApi.Services.Interfaces;

public interface IRegisterService
{
    Task<RegisterErrors?> RegisterUser(CreateUserModelDto createDto);
}