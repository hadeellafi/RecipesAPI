using RecipesAPI.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.DTOs.PostDtos
{
    public class PostDto
    {
        public int PostID { get; set; }
        public required string Name { get; set; }
        public string? RecipeDescription { get; set; }
        public string? Photo { get; set; }

        // Navigation properties
        public required string UserID { get; set; }
        public List<IngredientOfPost>? Ingredients { get; set; }
        public List<StepDto>? Steps { get; set; }
        public bool IsUpdated { get; set; }

        public IFormFile? PhotoFile { get; set; }
    }
}
