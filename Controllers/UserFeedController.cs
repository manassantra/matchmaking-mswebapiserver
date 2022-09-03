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
            if (user == null) return BadRequest();

            var post = new UserFeed
            {
                userRefId = userFeed.userRefId,
                postDescription = userFeed.postDescription,
                createdAt = DateTime.Now,
                createdBy = user.email,
                isDeleted = false
            };

            _context.UserFeeds.Add(post);
            await _context.SaveChangesAsync();

            return Ok("Post Created Successfully ! ");
        }


        [HttpGet("getpost/{id}")]
        public async Task<ActionResult> GetUsersPost(int id)
        {
            IList<UserFeed> posts = _context.UserFeeds.ToList();
            var result = posts.Where(x => x.userRefId == id).ToList();
            if (result.Count == 0) return NotFound("No Post Available");
            return Ok(result);
            
        }

    }
}
