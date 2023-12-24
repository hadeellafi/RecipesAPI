using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RecipesAPI.Models.DTOs.AuthDtos;
using RecipesAPI.Models.Interfaces;
using System.Security.Claims;

namespace RecipesAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuth authService;
        public AuthController(IAuth service)
        {
            this.authService = service;
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public async Task<ActionResult<UserAuthenticationDto>> Register(RegisterUserDto data)
        {
            var user = await authService.Register(data, this.ModelState);

            if (ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<UserAuthenticationDto>> Login(LoginDataDto loginDto)
        {
            var user = await authService.LogIn(loginDto.Username, loginDto.Password);

            if (user == null)
            {
                return Unauthorized(new { Message = "Invalid username or password" });
            }
            return user;
        }

    }
}

