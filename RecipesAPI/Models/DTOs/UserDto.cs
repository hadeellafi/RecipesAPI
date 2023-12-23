using RecipesAPI.Models.Entities;

namespace RecipesAPI.Models.DTOs
{
    public class UserDto
    {
        public required string Id { get; set; }
        public required string Username { get; set; }
        public   string FullName { get; set; }

        //public IList<string>? Roles { get; set; }

        public required string ProfilePicture { get; set; }

        public string? Description { get; set; }
        public List<Post>? Posts { get; set; }
        public List<FollowDto>? Followers { get; set; }
        public List<FollowDto>? Following { get; set; }

        public bool ? IsFollowing { get; set; }

    }
}
