using IdentityApi.Dtos;
using IdentityApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService service;

    public LoginController(ILoginService service)
    {
        this.service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post(LoginRequest request)
    {
        try
        {
            TokenModel? token = await service.LogaUsuario(request);
            if (token != null) return Ok(token);
        }
        catch (Exception)
        {
            return BadRequest();
        }
        return Unauthorized();
    }
}
