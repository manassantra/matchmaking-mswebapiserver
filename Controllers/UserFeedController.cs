using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using mswebapiserver.DTOs;
using mswebapiserver.Models;

namespace mswebapiserver.Controllers
{
    public class UserFeedController : BaseapiController
    {
        private readonly DatabaseContext _context;

        public UserFeedController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpPost("post/{id}")]
        public async Task<ActionResult<UserFeedDTO>> CreatePost(int id, UserFeedDTO userFeed)
        {
            var user = await _context.AppUsers.FindAsync(id);
            var gallery = _context.ImageGallery.Where(x=> x.postBatchId == userFeed.postBatchId).ToList();

            if (user == null) return BadRequest();

            var post = new UserFeed
            {
                userRefId = id,
                postDescription = userFeed.postDescription,
                postBatchId = userFeed.postBatchId,
                imageDetails = gallery,
                createdAt = DateTime.Now,
                createdBy = user.email,
                isDeleted = false
            };

          //  return Ok(post);

            _context.UserFeeds.Add(post);
            _context.SaveChanges();
            return Ok(post);
        }


        [HttpGet("getpost/{id}")]
        public async Task<ActionResult<UserFeed>> GetUsersPost(int id)
        {
            IList<UserFeed> posts = _context.UserFeeds.Where(x=> x.userRefId == id).ToList();
            foreach (var post in posts)
            {
                List<UserGallery> gal = _context.ImageGallery.Where(x=> x.postBatchId==post.postBatchId).ToList();
                post.imageDetails = gal;
            }
            return Ok(posts);
        }

    }
}
