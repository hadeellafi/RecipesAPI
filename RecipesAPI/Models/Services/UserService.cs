using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecipesAPI.Data;
using RecipesAPI.Models.DTOs;
using RecipesAPI.Models.Entities;
using RecipesAPI.Models.Interfaces;

namespace RecipesAPI.Models.Services
{
    public class UserService : IUser
    {

        private readonly RecipesDbContext _context;

        public UserService(RecipesDbContext context)
        {

            this._context = context;
        }



        public async Task<bool> FollowUser(string userId, string followerId)
        {
            // Check if the follow relationship already exists
            var follow = await _context.Follows.FirstOrDefaultAsync(f => f.UserID == userId && f.FollowerID == followerId);
            if (follow != null)
            {
                return false;
            }
            follow = new Follow
            {
                UserID = userId,
                FollowerID = followerId
            };

            _context.Follows.Add(follow);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UnfollowUser(string userId, string followerId)
        {
            // Find the follow relationship in the database
            var follow = await _context.Follows.FirstOrDefaultAsync(f => f.UserID == userId && f.FollowerID == followerId);
            if (follow == null)
            {
                return false;
            }

            _context.Follows.Remove(follow);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<BioDto> GetUserBioProfile(string userId, string currentUserId)
        {
            var user = await _context.Users.Include(u => u.Followers).ThenInclude(f => f.User)
                                            .Include(u => u.Following).ThenInclude(f => f.Follower)
                                            .Include(u => u.Posts)
                                            .FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                bool? isFollow = null;
                if (userId != currentUserId)
                {
                    var follow = await _context.Follows.FirstOrDefaultAsync(f => f.UserID == currentUserId && f.FollowerID == userId);
                    isFollow = follow != null;
                }
                var userDto = new BioDto
                {
                    Id = user.Id,
                    Username = user.UserName,
                    FullName = user.FullName,
                    ProfilePicture = user.ProfilePicture,
                    Description = user.Description,
                    IsFollowing = isFollow,
                    FollowingCount = user.Following?.Count ?? 0,
                    FollowersCount = user.Followers?.Count ?? 0,
                    PostsCount = user.Posts?.Count ?? 0
                };

                return userDto;
            }
            return null;
        }

       public async Task<List<UserBasicData>> GetFollowers(string userId)
{
    var user = await _context.Users.Include(u => u.Followers).ThenInclude(f => f.User)
                                   .FirstOrDefaultAsync(u => u.Id == userId);
    if (user != null)
    {
        var followers = user.Followers?.Select(f => new UserBasicData
        {
            UserID = f.User.Id,
            UserName = f.User.UserName,
            FullName = f.User.FullName,
            ProfilePicture = f.User.ProfilePicture
        }).ToList();

        return followers;
    }
    return null;
}

public async Task<List<UserBasicData>> GetFollowing(string userId)
{
    var user = await _context.Users.Include(u => u.Following).ThenInclude(f => f.Follower)
                                   .FirstOrDefaultAsync(u => u.Id == userId);
    if (user != null)
    {
        var following = user.Following?.Select(f => new UserBasicData
        {
            UserID = f.Follower.Id,
            UserName = f.Follower.UserName,
            FullName = f.Follower.FullName,
            ProfilePicture = f.Follower.ProfilePicture
        }).ToList();

        return following;
    }
    return null;
}

        //public async Task<BioDto> GetUserBioProfile(string userId, string currentUserId)
        //{
        //    var user = await _context.Users.Include(u => u.Followers).ThenInclude(f => f.User)
        //                                    .Include(u => u.Following).ThenInclude(f => f.Follower)
        //                                    .FirstOrDefaultAsync(u => u.Id == userId);
        //    if (user != null)
        //    {
        //        bool? isFollow=null;
        //        if (userId != currentUserId)
        //        { 
        //            var follow = await _context.Follows.FirstOrDefaultAsync(f => f.UserID == currentUserId && f.FollowerID == userId);
        //            if (follow != null)
        //            {
        //                isFollow = true;
        //            }
        //            else
        //            { isFollow = false; }

        //        }
        //        var userDto = new BioDto
        //        {
        //            Id = user.Id,
        //            Username = user.UserName,
        //            FullName = user.FullName,
        //            ProfilePicture = user.ProfilePicture,

        //            Description = user.Description,
        //            IsFollowing = isFollow,
        //            ////user.Posts.Select(p => new PostDTO { /* map properties here */ }).ToList()
        //            Followers = user.Followers?.Select(f => new FollowDto
        //            {
        //                UserID = f.UserID,
        //                User = new UserDto { Id = f.User.Id, Username = f.User.UserName, ProfilePicture = f.User.ProfilePicture },
        //                FollowerID = f.FollowerID,
        //                //Follower = new UserDto { Id = f.Follower.Id, Username = f.Follower.UserName, ProfilePicture = f.Follower.ProfilePicture, Token = "" },
        //                IsFollowing = f.UserID == currentUserId
        //            }).ToList(),
        //            Following = user.Following?.Select(f => new FollowDto
        //            {
        //                UserID = f.UserID,
        //                //User = new UserDto { Id = f.User.Id, Username = f.User.UserName, ProfilePicture = f.User.ProfilePicture, Token = "" },
        //                FollowerID = f.FollowerID,
        //                Follower = new UserDto { Id = f.Follower.Id, Username = f.Follower.UserName, ProfilePicture = f.Follower.ProfilePicture },
        //                IsFollowing = f.FollowerID == currentUserId
        //            }).ToList()
        //        };

        //        return userDto;
        //    }
        //    return null;
        //}
    }

}

