using RecipesAPI.Models.DTOs.PostDtos;
using RecipesAPI.Models.Entities;

namespace RecipesAPI.Models.Interfaces
{
    public interface IPost
    {
        Task<List<Ingredient>> GetIngredients();
        Task<List<Ingredient>> CreateIngredient(Ingredient ingredient);

        Task<bool> CreatePost(PostDto postToCreate,IFormFile PhotoFile);
        Task AddIngredientsToPost(int postId, List<IngredientOfPost> ingredients);


    }
}
