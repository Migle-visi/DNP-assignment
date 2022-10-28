using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext _context;
    
    public PostFileDao(FileContext context)
    {
        this._context = context;
    }

    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        if (_context.Posts.Any())
        {
            postId = _context.Posts.Max(p => p.Id);
            postId++;
        }
        post.Id = postId;
        _context.Posts.Add(post);
        _context.SaveChanges();

        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParameters searchDto)
    {
        IEnumerable<Post> result = _context.Posts.AsEnumerable();

        if (searchDto.UserId != null)
        {
            result = result.Where(p => p.Owner.Id== searchDto.UserId);
        }

        if (!string.IsNullOrEmpty(searchDto.Title))
        {
            result = result.Where(p => p.Title.Contains(searchDto.Title, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(result);
    }
    
}