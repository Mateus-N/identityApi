using System.ComponentModel.DataAnnotations;

namespace IdentityApi.Dtos;

public record CreateUserModelDto
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    [Required]
    [Compare("Password")]
    public required string RePassword { get; set; }
}
