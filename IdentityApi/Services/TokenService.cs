using IdentityApi.Dtos;
using IdentityApi.MarkupInterfaces;
using IdentityApi.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityApi.Services;

public class TokenService : ITokenService, IInjectable
{
    public TokenModel CreateToken(IdentityUser<Guid> usuario)
    {
        Claim[] direitosUsuario = new Claim[]
        {
            new Claim("id", usuario.Id.ToString()),
        };

        var chave = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")
        );

        var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: direitosUsuario,
            signingCredentials: credenciais,
            expires: DateTime.UtcNow.AddHours(1)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return new TokenModel(tokenString);
    }
}
