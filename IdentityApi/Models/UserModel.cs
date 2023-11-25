using System.ComponentModel.DataAnnotations;

namespace IdentityApi.Models;

public record UserModel
{
    [Key]
    [Required]
    public required Guid Id { get; set; }
    [Required]
    [MinLength(4)]
    public required string UserName { get; set; }
    [Required]
    public required string Email { get; set; }
}
