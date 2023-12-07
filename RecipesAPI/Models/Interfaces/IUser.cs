using Microsoft.AspNetCore.Mvc.ModelBinding;
using RecipesAPI.Models.DTOs;

namespace RecipesAPI.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState);

        public Task<UserDto> LogIn(string username, string password);

        //public Task<UserDto> GetUser(string username);
        public Task Logout();
    }
}
