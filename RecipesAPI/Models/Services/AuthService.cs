using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.DTOs;
using RecipesAPI.Models.Entities;
using RecipesAPI.Models.Interfaces;
using System.Security.Claims;

namespace RecipesAPI.Models.Services
{
    public class AuthService : IAuth
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly JwtTokenService tokenService;
        private readonly RecipesDbContext _context;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, JwtTokenService tokenService, RecipesDbContext context)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
            this._context = context;
        }



        ////public async Task<UserAuthenticationDto> GetUser(ClaimsPrincipal principal)
        ////{
        ////    var user = await userManager.GetUserAsync(principal);

        ////    return new UserAuthenticationDto
        ////    {
        ////        Id = user.Id,
        ////        Username = user.UserName,
        ////        FullName=user.FullName,
        ////        Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5)),
        ////        ProfilePicture = user.ProfilePicture
        ////    };
        ////}

        public async Task<UserAuthenticationDto> LogIn(string username, string password)
        {
            var user = await userManager.FindByNameAsync(username);
            bool vaildPassword = await userManager.CheckPasswordAsync(user, password);
            if (vaildPassword)
            {
                return new UserAuthenticationDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FullName = user.FullName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5)),
                    ProfilePicture = user.ProfilePicture
                };

            }
            return null;
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<UserAuthenticationDto> Register(RegisterUserDto registerUser, ModelStateDictionary modelState)
        {
            var user = new User
            {
                UserName = registerUser.Username,
                Email = registerUser.Email,
                ProfilePicture = "https://storageaccbookimages.blob.core.windows.net/images/user.jpeg",
                FullName = registerUser.FullName,
                Description = ""
            };
            var result = await userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                //await userManager.AddToRolesAsync(user, registerUser.Roles);

                return new UserAuthenticationDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FullName = registerUser.FullName,
                    Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(5)),
                    ProfilePicture = user.ProfilePicture,

                    //Roles = await userManager.GetRolesAsync(user),
                };
            }
            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(registerUser.Password) :
                             error.Code.Contains("Email") ? nameof(registerUser.Email) :
                             error.Code.Contains("UserName") ? nameof(registerUser.Username) :
                             "General";

                modelState.AddModelError(errorKey, error.Description);
            }
            return null;
        }

    } 
}
