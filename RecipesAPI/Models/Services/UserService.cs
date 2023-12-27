using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RecipesAPI.Data;
using RecipesAPI.Models.DTOs;
using RecipesAPI.Models.Entities;
using RecipesAPI.Models.Interfaces;

namespace RecipesAPI.Models.Services
{
    public class UserService : IUser
    {

        private readonly RecipesDbContext _context;
        private readonly IConfiguration _configuration;


        public UserService(RecipesDbContext context, IConfiguration configuration)
        {

            _context = context;
            _configuration = configuration;
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

        //public async Task<List<UserBasicData>> GetFollowers(string userId)
        //{
        //    var user = await _context.Users.Include(u => u.Followers).ThenInclude(f => f.User)
        //                                   .FirstOrDefaultAsync(u => u.Id == userId);
        //    if (user != null)
        //    {
        //        var followers = user.Followers?.Select(async f => new UserBasicData
        //        {
        //            UserID = f.User.Id,
        //            UserName = f.User.UserName,
        //            FullName = f.User.FullName,
        //            ProfilePicture = f.User.ProfilePicture,
        //            IsFollowing = await _context.Follows.AnyAsync(follow => follow.UserID == userId && follow.FollowerID == f.User.Id) // Check if the current user is following the follower
        //        }).ToList();

        //        return followers;
        //    }
        //    return null;
        //}
        public async Task<List<UserBasicData>> GetFollowers(string currentId, string userId)
        {
            var user = await _context.Users.Include(u => u.Followers).ThenInclude(f => f.User)
                                           .FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                var followerTasks = user.Followers?.Select(async f => new UserBasicData
                {
                    UserID = f.User.Id,
                    UserName = f.User.UserName,
                    FullName = f.User.FullName,
                    ProfilePicture = f.User.ProfilePicture,
                    IsFollowing = await _context.Follows.AnyAsync(follow => follow.UserID == currentId && follow.FollowerID == f.FollowerID)
                });

                var followers = followerTasks != null ? await Task.WhenAll(followerTasks) : null;

                return followers?.ToList();
            }
            return null;
        }


        public async Task<List<UserBasicData>> GetFollowing(string currentId, string userId)
        {
            var user = await _context.Users.Include(u => u.Following).ThenInclude(f => f.Follower)
                                           .FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                var followingTasks = user.Following?.Select(async f => new UserBasicData
                {
                    UserID = f.Follower.Id,
                    UserName = f.Follower.UserName,
                    FullName = f.Follower.FullName,
                    ProfilePicture = f.Follower.ProfilePicture,
                    IsFollowing = await _context.Follows.AnyAsync(follow => follow.UserID == currentId && follow.FollowerID == f.FollowerID)
                });

                var following = followingTasks != null ? await Task.WhenAll(followingTasks) : null;

                return following?.ToList();
            }
            return null;
        }

        public async Task<string> DeleteProfilePicture(string userId)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user != null)
            {
                user.ProfilePicture = "https://projectsstorage2001.blob.core.windows.net/recipeimages/default_avatar.jpg";
                await _context.SaveChangesAsync();
                return user.ProfilePicture;
            }
            return null;
                }

        public async Task<string> updateProfilePicture(string userId, IFormFile ImageFile)
        {
           var user=await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            
                if (user != null) {
                user.ProfilePicture = await ReturnUrlOfImage(ImageFile);
                await _context.SaveChangesAsync();
                return user.ProfilePicture;

            }
            return null;
            
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
        public async Task<bool> UpdateUserData(string userId,BioDto bio)
        {
            var user=await _context.Users.FirstOrDefaultAsync(u=>u.Id == userId);
            if (user != null)
            {
                user.FullName = bio.FullName;
                user.Description = bio.Description;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
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

