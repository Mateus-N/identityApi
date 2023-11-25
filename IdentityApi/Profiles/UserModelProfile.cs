using AutoMapper;
using IdentityApi.Dtos;
using IdentityApi.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityApi.Profiles;

public class UserModelProfile : Profile
{
    public UserModelProfile()
    {
        CreateMap<CreateUserModelDto, UserModel>();
        CreateMap<UserModel, IdentityUser<Guid>>();
    }
}
