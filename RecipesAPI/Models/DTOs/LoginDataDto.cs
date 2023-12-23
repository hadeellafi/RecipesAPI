using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Models.DTOs
{
    public class LoginDataDto
    {
        public required string Username { get; set; }

        public required string Password { get; set; }
    }
}
