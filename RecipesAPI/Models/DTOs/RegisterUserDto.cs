using System.ComponentModel.DataAnnotations;

namespace RecipesAPI.Models.DTOs
{
    public class RegisterUserDto
    {
       
        public required string Username { get; set; }

        public required string FullName { get; set; }

        public required string Password { get; set; }

        public required string Email { get; set; }

        //        public List<string> Roles { get; set; }
    }
}
