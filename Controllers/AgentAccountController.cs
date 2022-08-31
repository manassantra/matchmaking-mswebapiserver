using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mswebapiserver.Interfaces;
using mswebapiserver.Models;
using mswebapiserver.Services;

namespace mswebapiserver.Controllers
{
    public class AgentAccountController : BaseapiController
    {
        private readonly DatabaseContext _context;
        private readonly ITokenService _tokenService;
        public AgentAccountController(DatabaseContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }   


        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IList<AgentUser>> GetAllUser()
        {
            return _context.AgentUsers.ToList();
        }
    }
}
