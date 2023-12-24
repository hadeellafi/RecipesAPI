using RecipesAPI.Models.Entities;

namespace RecipesAPI.Models.DTOs.AuthDtos
{
    public class UserAuthenticationDto
    {
        public required string Id { get; set; }
        public required string Username { get; set; }
        public required string FullName { get; set; }

        public required string Token { get; set; }
        public required string ProfilePicture { get; set; }

    }
}
