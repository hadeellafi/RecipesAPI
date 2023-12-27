using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecipesAPI.Models.DTOs.PostDtos;
using RecipesAPI.Models.Interfaces;

namespace RecipesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPost postService;
        public PostsController(IPost service)
        {
            this.postService = service;
        }
        //[HttpPost]
        //public async Task<ActionResult<bool>> CreatePost([FromForm] PostDto postDto)
        //{
        //    return await postService.CreatePost(postDto);
        //}
        [HttpPost("Create")]
        public async Task<ActionResult<bool>> CreatePost(string postDtoJson, IFormFile img)
        {
            PostDto postDto = JsonConvert.DeserializeObject<PostDto>(postDtoJson);
            return await postService.CreatePost(postDto, img);
        }

    }
}
