using Microsoft.AspNetCore.Mvc;
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
                batchId = userFeed.batchRefId,
                postDescription = userFeed.postDescription,
                createdAt = DateTime.Now,
                createdBy = user.email,
                isDeleted = false
            };

            _context.UserFeeds.Add(post);
            await _context.SaveChangesAsync();

            return Ok("Post Created Successfully ! ");
        }

    }
}
