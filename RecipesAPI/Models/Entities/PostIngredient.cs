using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.Entities
{
    public class PostIngredient
    {
        [ForeignKey("PostID")]
        public int PostID { get; set; }
        public Post? Post { get; set; }

        [ForeignKey("IngredientID")]
        public int IngredientID { get; set; }
        public Ingredient? Ingredient { get; set; }

        public required string Quantity { get; set; }
    }
}
