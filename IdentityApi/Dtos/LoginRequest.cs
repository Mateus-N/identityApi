using System.ComponentModel.DataAnnotations;

namespace IdentityApi.Dtos;

public record LoginRequest
{
    [Required]
    public required string UserName { get; set; }
    [Required]
    public required string Password { get; set; }
}
