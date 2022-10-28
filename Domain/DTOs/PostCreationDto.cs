using Domain.Models;

namespace Domain.DTOs;

public class PostCreationDto
{
    public string Title { get; set; }
    public int OwnerId { get; set; }
    public string Body { get; set; }

    public PostCreationDto(int ownerId, string title, string body)
    {
        OwnerId = ownerId;
        Title = title;
        Body = body;
    }
}