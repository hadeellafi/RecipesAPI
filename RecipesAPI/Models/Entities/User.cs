using Microsoft.AspNetCore.Identity;

namespace RecipesAPI.Models.Entities
{
    public class User: IdentityUser
    {
        public string ProfilePicture { get; set; }

        // Navigation properties
        public List<Post>? Posts { get; set; }
        public List<Follow>? Followers { get; set; }
        public List<Follow>? Following { get; set; }
    }
}
