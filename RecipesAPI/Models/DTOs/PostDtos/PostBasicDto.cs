using RecipesAPI.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesAPI.Models.DTOs.PostDtos
{
    public class PostBasicDto
    {
        public int PostID { get; set; }
        public required string Name { get; set; }
        public required string Photo { get; set; }     
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
      
    }
}

