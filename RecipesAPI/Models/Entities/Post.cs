using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.Entities
{
    public class Post
    {
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Recipe { get; set; }
        public string Photo { get; set; }
        public DateTime DatePosted { get; set; }
        // Navigation properties
        [ForeignKey("UserID")]

        public string UserID { get; set; }
        public User? User { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public List<Step>? Steps { get; set; }
        public List<Like>? Likes { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
