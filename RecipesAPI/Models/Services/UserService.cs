using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Models.DTOs;
using RecipesAPI.Models.Entities;
using RecipesAPI.Models.Interfaces;

namespace RecipesAPI.Models.Services
{
    public class UserService : IUser
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public UserService(UserManager<User> manager, SignInManager<User> signInManager)
        {
            _userManager = manager;
            _signInManager = signInManager;
        }
        public async Task<UserDto> LogIn(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == username);

                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Roles = await _userManager.GetRolesAsync(user),
                    ProfilePicture=user.ProfilePicture
                };
            }

            return null;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState)
        {
            var user = new User()
            {
                UserName = data.Username,
                Email = data.Email,
                ProfilePicture= "https://storageaccbookimages.blob.core.windows.net/images/DefultPicture.png"
            };

            var result = await _userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {

                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    ProfilePicture = user.ProfilePicture 
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey = error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                     error.Code.Contains("Email") ? nameof(data.Email) :
                     "";

                modelState.AddModelError(errorKey, error.Description);
            }

            return null;
        }
    }
}
