using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Models.DTOs.AuthDtos
{
    public class LoginDataDto
    {
        public required string Username { get; set; }

        public required string Password { get; set; }
    }
}
