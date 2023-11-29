using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Text { get; set; }
        public DateTime DateCommented { get; set; }

        // Navigation properties
        [ForeignKey("UserID")]
        public string? UserID { get; set; }
        public User? User { get; set; }

        [ForeignKey("PostID")]

        public int? PostID { get; set; }
        public Post? Post { get; set; }
    }
}
