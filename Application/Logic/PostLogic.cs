using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }
    
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.OwnerId);
        
            if (user == null)
            {
                throw new Exception($"User with id {dto.OwnerId} was not found.");
            }
        
        ValidateTodo(dto);
        Post created = await postDao.CreateAsync(new Post(user, dto.Title, dto.Body));
        return created;
    }

    private void ValidateTodo(PostCreationDto dto)
    {
        string title = dto.Title;
        if (string.IsNullOrEmpty(title)) throw new Exception("Title cannot be empty.");

        string body = dto.Body;
        if (string.IsNullOrEmpty(body)) throw new Exception("Body cannot be empty. ");
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParameters searchdto)
    {
        return postDao.GetAsync(searchdto);
    }
}