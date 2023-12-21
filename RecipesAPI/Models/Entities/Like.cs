using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.Entities
{
    public class Like
    {
        // Navigation properties

        [ForeignKey("UserID")]
        public string UserID { get; set; }
        public User? User { get; set; }

        [ForeignKey("PostID")]

        public int PostID { get; set; }
        public Post? Post { get; set; }
    }
}
