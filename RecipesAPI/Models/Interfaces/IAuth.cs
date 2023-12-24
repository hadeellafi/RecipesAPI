using Microsoft.AspNetCore.Mvc.ModelBinding;
using RecipesAPI.Models.DTOs.AuthDtos;
using System.Security.Claims;

namespace RecipesAPI.Models.Interfaces
{
    public interface IAuth
    {
        public Task<UserAuthenticationDto> Register(RegisterUserDto registerUser, ModelStateDictionary modelState);

        public Task<UserAuthenticationDto> LogIn(string username, string password);

        public Task Logout();

       


    }
}
