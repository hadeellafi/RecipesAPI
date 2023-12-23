using RecipesAPI.Models.DTOs;

namespace RecipesAPI.Models.Interfaces
{
    public interface IUser
    {
        public Task<BioDto> GetUserBioProfile(string userId, string currentUserId);
        public Task<bool> FollowUser(string userId, string followerId);
        public Task<bool> UnfollowUser(string userId, string followerId);

        public Task<List<UserBasicData>> GetFollowers(string userId);
        public Task<List<UserBasicData>> GetFollowing(string userId);

    }
}
