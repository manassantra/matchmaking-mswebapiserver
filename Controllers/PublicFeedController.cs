using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using mswebapiserver.Models;
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
            IList<UserFollower> followers = _context.UserFollowers.Where(x => x.userId == id).ToList();
            foreach (var follower in followers)
            {
                IList<UserFeed> friendsPost = _context.UserFeeds.Where(x => x.userRefId == follower.followedUserId).ToList();
                foreach (var post in friendsPost)
                {
                    List<UserGallery> gal = _context.ImageGallery.Where(x => x.postBatchId == post.postBatchId).ToList();
                    post.imageDetails = gal;
                }
                return Ok(friendsPost);
            }

            return Ok();
        }
    }
}
