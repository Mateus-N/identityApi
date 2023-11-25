using AutoMapper;
using IdentityApi.Dtos;
using IdentityApi.MarkupInterfaces;
using IdentityApi.Models;
using IdentityApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Services;

public class RegisterService : IRegisterService, IInjectable
{
    private readonly IMapper mapper;
    private readonly IIdentityRegisterService identityRegisterService;

    public RegisterService(IMapper mapper, IIdentityRegisterService identityRegisterService)
    {
        this.identityRegisterService = identityRegisterService;
        this.mapper = mapper;
    }

    public async Task<RegisterErrors?> RegisterUser(CreateUserModelDto createDto)
    {
        UserModel userModel = mapper.Map<UserModel>(createDto);
        IdentityUser<Guid> identityUser = mapper.Map<IdentityUser<Guid>>(userModel);

        return await identityRegisterService.Register(identityUser, createDto);
    }
}
