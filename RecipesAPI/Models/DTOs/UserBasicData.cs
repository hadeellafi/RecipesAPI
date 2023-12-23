namespace RecipesAPI.Models.DTOs
{
    public class UserBasicData
    {
        public required string UserID { get; set; }
        public required string UserName { get; set; }
        public required string FullName { get; set; }
        public required string ProfilePicture { get; set; }

        public bool IsFollowing { get; set; }

    }
}
