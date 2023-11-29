using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.Entities
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public string Quantity { get; set; }
        // Navigation properties

        [ForeignKey("PostID")]
        public int PostID { get; set; }
        public Post? Post { get; set; }
    }
}
