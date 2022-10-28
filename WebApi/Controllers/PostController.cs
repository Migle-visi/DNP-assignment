using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]/[action]")]

public class PostController : ControllerBase
{
   private readonly IPostLogic postLogic;

   public PostController(IPostLogic postLogic)
   {
      this.postLogic = postLogic;
   }

   [HttpPost]
   public async Task<ActionResult<Post>> CreateAsync([FromBody]PostCreationDto dto)
   {
      try
      {
         Post post = await postLogic.CreateAsync(dto);
         return Created($"/post/{post.Id}", post);
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         return StatusCode(500, e.Message);
      }
   }

   [HttpGet]
   public async Task<ActionResult<IEnumerable<Post>>> GetAsync([FromQuery] string? title)
   {
      try
      {
         SearchPostParameters searchDto = new(title);
         var posts = await postLogic.GetAsync(searchDto);
         return Ok(posts);
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         return StatusCode(500, e.Message);
      }
   }

}