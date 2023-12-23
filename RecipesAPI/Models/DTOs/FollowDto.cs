using RecipesAPI.Models.Entities;

namespace RecipesAPI.Models.DTOs
{
    public class FollowDto
    {
        public required string UserID { get; set; }
        public UserDto? User { get; set; }

        public required string FollowerID { get; set; }
        public UserDto? Follower { get; set; }
        public bool IsFollowing { get; set; }

    }
}
