namespace Domain.DTOs;

public class SearchPostParameters
{
    public string Title { get; set; }
    public int? UserId { get; set; }

    public SearchPostParameters(string title)
    {
        Title = title;
    }
}