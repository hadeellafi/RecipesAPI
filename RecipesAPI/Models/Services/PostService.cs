using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipesAPI.Data;
using RecipesAPI.Models.DTOs.PostDtos;
using RecipesAPI.Models.Entities;
using RecipesAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.Services
{
    public class PostService : IPost
    {
        private readonly RecipesDbContext _context;
        private readonly IConfiguration _configuration;

        public PostService(RecipesDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }



        public async Task<List<Ingredient>> CreateIngredient(Ingredient ingredient)
        {

            await _context.Ingredients.AddAsync(ingredient);
            return await GetIngredients();
        }


        public async Task<List<Ingredient>> GetIngredients()
        {
            var ingredients = await _context.Ingredients.ToListAsync();

            return ingredients;
        }

        public async Task<bool> CreatePost(PostDto postToCreate,IFormFile PhotoFile)
        {
            string? pic = null;
            if (PhotoFile != null)
            {
                pic = await ReturnUrlOfImage(PhotoFile);
            }
            Post post = new Post
            {
                Name = postToCreate.Name,
                RecipeDescription = postToCreate.RecipeDescription,
                Photo = pic,
                DatePosted = DateTime.Now,
                UserID = postToCreate.UserID,
                IsUpdated = false
            };
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();

            if (postToCreate.Steps != null && postToCreate.Steps.Count > 0)
            {
                await AddStepsToPost(post.PostID, postToCreate.Steps);
            }

            // After creating the post and steps, if the list of ingredients is not empty, call AddIngredientsToPost
            if (postToCreate.Ingredients != null && postToCreate.Ingredients.Count > 0)
            {
                await AddIngredientsToPost(post.PostID, postToCreate.Ingredients);
            }

            return true;
        }

        public async Task AddStepsToPost(int PostId, List<StepDto> steps)
        {
            foreach (var stepDto in steps)
            {
                var step = new Step
                {
                    Instruction = stepDto.Instruction,
                    PostID = PostId
                };
                await _context.Steps.AddAsync(step);
            }
            await _context.SaveChangesAsync();
        }




        public async Task<string> ReturnUrlOfImage(IFormFile file)
        {

            // Create a public container
            BlobContainerClient blobContainerClient = new BlobContainerClient(_configuration.GetConnectionString("StorageAccount"), "recipeimages");
            blobContainerClient.CreateIfNotExists(PublicAccessType.Blob);

            // Create if images container not exist 
            await blobContainerClient.CreateIfNotExistsAsync();


            BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);

            using var fileStream = file.OpenReadStream();

            BlobUploadOptions blobUploadOptions = new BlobUploadOptions()
            {
                HttpHeaders = new BlobHttpHeaders { ContentType = file.ContentType }
            };

            if (!blobClient.Exists())
            {
                await blobClient.UploadAsync(fileStream, blobUploadOptions);
            }

            return blobClient.Uri.ToString();

        }

        public async Task AddIngredientsToPost(int postId,List<IngredientOfPost> ingredients)
        {
            var post = await _context.Posts.FindAsync(postId);
            if (post == null)
            {
                throw new Exception("Post not found");
            }

            foreach (var ingredient in ingredients)
            {
                var postIngredient = new PostIngredient
                {
                    PostID = postId,
                    IngredientID = ingredient.IngredientID,
                    Quantity = ingredient.Quantity
                };
                await _context.PostIngredients.AddAsync(postIngredient);
            }
            await _context.SaveChangesAsync();
        }
    }
}