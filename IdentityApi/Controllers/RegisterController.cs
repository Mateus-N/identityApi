using IdentityApi.Dtos;
using IdentityApi.Models;
using IdentityApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{
    private readonly IRegisterService service;

    public RegisterController(IRegisterService service)
    {
        this.service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]CreateUserModelDto userDto)
    {
        try
        {
            RegisterErrors? errors = await service.RegisterUser(userDto);
            if (errors == null) return Ok();
            return Conflict(errors);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
