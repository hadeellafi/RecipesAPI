using RecipesAPI.Models.Entities;

namespace RecipesAPI.Models.DTOs
{
    public class UserSocialDto
    {
        public required string Id { get; set; }
        public List<Post>? Posts { get; set; }
    }
}
