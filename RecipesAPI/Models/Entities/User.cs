using Microsoft.AspNetCore.Identity;

namespace RecipesAPI.Models.Entities
{
    public class User: IdentityUser
    {

        public required string FullName { get; set; }

        public string ProfilePicture { get; set; }

        public string? Description { get; set; }

        // Navigation properties
        public List<Post>? Posts { get; set; }
        public List<Follow>? Followers { get; set; }
        public List<Follow>? Following { get; set; }
    }
}
