//using Microsoft.EntityFrameworkCore;
//using RecipesAPI.Data;
//using RecipesAPI.Models.DTOs.PostDtos;
//using RecipesAPI.Models.Entities;
//using RecipesAPI.Models.Interfaces;
//using System.Linq;

//namespace RecipesAPI.Models.Services
//{
//    public class IngreadientService : IIngredient
//    {
//        private readonly RecipesDbContext _context;
//        public IngreadientService(RecipesDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<IngredientDto>> CreateIngredient(IngredientDto ingredient)
//        {
//            Ingredient ingredientToAdd = new Ingredient
//            {
//                IngredientName = ingredient.IngredientName
//            };
//            await _context.Ingredients.AddAsync(ingredientToAdd);
//            return await GetIngredients();
//        }

//        public async Task<List<IngredientDto>> GetIngredients()
//        {
//            var ingredients = await _context.Ingredients.ToListAsync();
//            List<IngredientDto> ingredientsDto = ingredients.Select(i => new IngredientDto
//            {
//                IngredientID = i.IngredientID,
//                IngredientName = i.IngredientName
//            }).ToList();
//            return ingredientsDto;
//        }

//    }
//}
