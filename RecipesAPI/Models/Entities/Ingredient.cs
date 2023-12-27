using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.Entities
{
    public class Ingredient
    {
        public int IngredientID { get; set; }
        public required string IngredientName { get; set; }
       
        public List<PostIngredient>? PostIngredients { get; set; }

    }
}
