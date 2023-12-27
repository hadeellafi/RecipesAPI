using RecipesAPI.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.DTOs.PostDtos
{
    public class IngredientOfPost
    {
       
        public int IngredientID { get; set; }
    
        public required string Quantity { get; set; }
    }
}
