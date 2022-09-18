using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using mswebapiserver.DTOs;
using mswebapiserver.Models.User;
using NuGet.Packaging;
using System.Collections.Generic;
using System.Linq;

namespace mswebapiserver.Controllers
{

    public class PublicFeedController : BaseapiController
    {
        private readonly DatabaseContext _context;

        public PublicFeedController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet("getpost/{id}")]
        public async Task<ActionResult<UserFeed>> GetAllPFPost(int id)
        {
            var postList = new List<UserFeed>();    
            List<UserFollower> followers = _context.UserFollowers.Where(x => x.userId == id).ToList();
            for(int i = 0; i < followers.Count; i++)
            {
                var userFollower = followers[i].followedUserId;
                var allPost = _context.UserFeeds.Where(x => x.userRefId == userFollower).ToList();
                postList.AddRange(allPost);
            }
            foreach (var post in postList)
            {
                List<UserGallery> userGalleries = _context.ImageGallery.Where(x => x.postBatchId == post.postBatchId).ToList();
                post.imageDetails = userGalleries;
            }
            return Ok(postList);
        }
    }
}
