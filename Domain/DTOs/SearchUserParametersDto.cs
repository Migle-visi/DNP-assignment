namespace Domain.DTOs;

public class SearchUserParametersDto
{
    public string? UsernameContains { get; set; }

    public SearchUserParametersDto(string? usernameContains)
    {
        this.UsernameContains = usernameContains;
    }
}