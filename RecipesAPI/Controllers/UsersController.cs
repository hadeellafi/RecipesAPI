using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipesAPI.Models.DTOs;
using RecipesAPI.Models.Interfaces;
using RecipesAPI.Models.Services;

namespace RecipesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser userService;
        public UsersController(IUser service)
        {
            this.userService = service;
        }
        //[Authorize]
        [HttpGet("ProfileBio")]
        public async Task<ActionResult<BioDto>> ProfileBio(string currentUserId, string userId)
        {
            var result = await userService.GetUserBioProfile(userId, currentUserId);

            return result == null ? NotFound() : result;
        }


        [HttpGet("Follow")]
        public async Task<ActionResult<bool>> Follow(string currentUserId, string followerId)
        {
            return await userService.FollowUser(currentUserId, followerId);
        }

        [HttpDelete("Unfollow")]
        public async Task<ActionResult<bool>> Unfollow(string currentUserId, string followerId)
        {
            return await userService.UnfollowUser(currentUserId, followerId);
        }


        [HttpGet("GetFollowers/{userId}")]
        public async Task<ActionResult<List<UserBasicData>>> GetFollowers(string userId)
        {
            var result = await userService.GetFollowers(userId);

            return result == null ? NotFound() : result;
        }
        [HttpGet("GetFollowing/{userId}")]
        public async Task<ActionResult<List<UserBasicData>>> GetFollowing(string userId)
        {
            var result = await userService.GetFollowing(userId);

            return result == null ? NotFound() : result;
        }
        
    }
}
