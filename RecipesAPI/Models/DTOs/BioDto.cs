namespace RecipesAPI.Models.DTOs
{
    public class BioDto
    {
        public required string Id { get; set; }
        public required string Username { get; set; }
        public required string FullName { get; set; }
        public required string ProfilePicture { get; set; }
        public string? Description { get; set; }
        public bool? IsFollowing { get; set; }
        public int FollowingCount { get; set; }
        public int FollowersCount { get; set; }
        public int PostsCount { get; set; }


    }
}
