using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Models.DTOs
{
    public class LoginDataDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
