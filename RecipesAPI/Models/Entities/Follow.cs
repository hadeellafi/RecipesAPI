using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.Entities
{
    public class Follow
    {
        public required string UserID { get; set; }
        public User? User { get; set; }

        public required string FollowerID { get; set; }
        public User? Follower { get; set; }
    }

}
