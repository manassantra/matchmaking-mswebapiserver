using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mswebapiserver.DTOs;
using mswebapiserver.Interfaces;
using mswebapiserver.Models;
using mswebapiserver.Models.User;
using NuGet.Protocol;

namespace mswebapiserver.Controllers
{

    public class FollowersController : BaseapiController
    {
        private readonly DatabaseContext _context;

        public FollowersController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet("following/{id}")]
        public async Task<ActionResult<UserFollower>> GetFollowings(int id)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == id);
            if (user == null) return BadRequest();

            IList<UserFollower> followers = _context.UserFollowers.Where(x => x.userId == id && x.isFollowing == true).ToList();
            return Ok(followers);
        }


        [HttpGet("followers/{id}")]
        public async Task<ActionResult<UserFollower>> GetFollowers(int id)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == id);
            if (user == null) return BadRequest();

            IList<UserFollower> followers = _context.UserFollowers.Where(x => x.followedUserId == id && x.isFollowing == true).ToList();
            return Ok(followers);
        }


        [HttpGet("request/{id}")]
        public async Task<ActionResult<UserFollower>> GetFolloweRequest(int id)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == id);
            if (user == null) return BadRequest();

            IList<UserFollower> request = _context.UserFollowers.Where(x => x.userId == id && x.isFollowing == false).ToList();
            return Ok(request);
        }


        [HttpPost("follow-request")]
        public async Task<ActionResult<UserFollower>> CreateFollower(FollowerDTO followerDto)
        {
            var follower = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == followerDto.userId);
            var followedByUser = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == followerDto.followedUserId);
            if (follower == null && followedByUser == null) return BadRequest();

            var userFollower = new UserFollower
            {
                userId = followerDto.userId,
                followedUserId = followerDto.followedUserId,
                followedDate = DateTime.Now,
                isFollowing = false
            };

            if (userFollower != null)
            {
                var notification = new UserNotification
                {
                    Notification = follower!.fullName + " Sent You a Follow Request",
                    userId = followedByUser!.id,
                    CreatedDate = DateTime.Now
                };
                _context.UserNotifications.Add(notification);
                await _context.SaveChangesAsync();  
            }
            _context.UserFollowers.Add(userFollower);
            await _context.SaveChangesAsync();

            return Ok("Sent Follow Request Successfully !");
        }


        [HttpPut("approve-followers")]
        public async Task<ActionResult<UserFollower>> ApproveFollowRequest(FollowerDTO followRequest)
        {
            var follower = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == followRequest.userId);
            var followedByUser = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == followRequest.followedUserId);
            if (follower == null && followedByUser == null) return BadRequest();

            var request = await _context.UserFollowers
                .FirstOrDefaultAsync(x => x.userId == followRequest.userId && x.followedUserId == followRequest.followedUserId);

            {
                request!.followedDate = DateTime.Now;
                request.isFollowing = true;
            }

            if (request.isFollowing == true)
            {
                var notification = new UserNotification
                {
                    Notification = followedByUser!.fullName + " Accept Your Follow Request",
                    userId = follower!.id,
                    CreatedDate = DateTime.Now
                };
                _context.UserNotifications.Add(notification);
                await _context.SaveChangesAsync();
            }

            _context.UserFollowers.Update(request);
            await _context.SaveChangesAsync();

            return Ok(followedByUser?.fullName + " Accepted You Request.");
        }

    }
}
