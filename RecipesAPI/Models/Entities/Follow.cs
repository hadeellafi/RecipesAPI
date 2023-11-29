using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.Entities
{
    public class Follow
    {
        public string UserID { get; set; }
        public User? User { get; set; }

        public string FollowerID { get; set; }
        public User? Follower { get; set; }
    }

}
