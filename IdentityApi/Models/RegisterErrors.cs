namespace IdentityApi.Models;

public record RegisterErrors
{
    public List<string> Errors { get; set; }

    public RegisterErrors(List<string> errors)
    {
        Errors = errors;
    }
}
