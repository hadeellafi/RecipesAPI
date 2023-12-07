using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Models.DTOs;
using RecipesAPI.Models.Interfaces;

namespace RecipesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser userService;
        public UsersController(IUser service)
        {
            this.userService = service;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterUserDto data)
        {
            var user = await userService.Register(data, this.ModelState);

            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }
        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDataDto loginDto)
        {
            var user = await userService.LogIn(loginDto.Username, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }
        //[Authorize]
        //[HttpGet("Profile")]
        //public async Task<ActionResult<UserDTO>> Profile()
        //{
        //    return await userService.GetUser(this.User); ;
        //}
    }
}
