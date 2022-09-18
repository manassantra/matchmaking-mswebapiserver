using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mswebapiserver.Models.User;

namespace mswebapiserver.Controllers
{

    public class NotificationsController : BaseapiController
    {
        private readonly DatabaseContext _context;

        public NotificationsController(DatabaseContext context)
        {
            _context = context;
        }



        [HttpGet("{id}")]
        public ActionResult<UserNotification> GetNotifications(int id)
        {
            var result = _context.UserNotifications.Where(x => x.userId == id).ToList();
            return Ok(result);
        }
    }
}
