using RecipesAPI.Models.DTOs;
using System.Threading.Tasks;

namespace RecipesAPI.Models.Interfaces
{
    public interface IUser
    {
        public Task<BioDto> GetUserBioProfile(string userId, string currentUserId);
        public Task<bool> FollowUser(string userId, string followerId);
        public Task<bool> UnfollowUser(string userId, string followerId);

        public Task<List<UserBasicData>> GetFollowers(string currentId, string userId);
        public Task<List<UserBasicData>> GetFollowing(string currentId, string userId);

        public Task<string> DeleteProfilePicture(string userId);
        public Task<string> updateProfilePicture(string userId, IFormFile ImageFile);
        public  Task<bool> UpdateUserData(string userId, BioDto bio);


    }
}
