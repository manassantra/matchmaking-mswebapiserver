using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mswebapiserver.DTOs;
using mswebapiserver.Interfaces;
using mswebapiserver.Models;
using System.Security.Cryptography;
using System.Text;

namespace mswebapiserver.Controllers
{
    public class AdminAccountController : BaseapiController
    {
        
        private readonly DatabaseContext _context;
        private readonly ITokenService _tokenService;

        public AdminAccountController(DatabaseContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }


        // POST - REGISTER / Create Account
        [HttpPost("create")]
        public async Task<ActionResult<AuthDTO>> Register(AdminuserRegisterDTO adminuserDto)
        {
            if (await ExistEmail(adminuserDto.email)) return BadRequest("User Allready exist with this email !");
            
                using var hmac = new HMACSHA512();
                var user = new AdminUser
                {
                    roleId = adminuserDto.roleId,
                    fullName = adminuserDto.fullName,
                    email = adminuserDto.email,
                    passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(adminuserDto.password)),
                    passwordSalt = hmac.Key,
                    createdDate = DateTime.Now,
                    modifiedDate = DateTime.Now,
                    modifiedBy = null,
                    isActive = true
                };
                _context.AdminUsers.Add(user);
                await _context.SaveChangesAsync();
               
                return new AuthDTO
                {
                    authId = user.id,
                    token = _tokenService.CreateToken(user),
                };
        }


        // Admin LOGIN 
        [HttpPost("login")]
        public async Task<ActionResult<AuthDTO>> Login(LoginDTO loginDto)
        {
            var user = await _context.AdminUsers
                .SingleOrDefaultAsync(x => x.email == loginDto.Email);

            // Check Account
            if (user == null) return Unauthorized("Invalid User");
            if (user.isActive == false) return Unauthorized("Account Deactivated");

            // Checking Password
            using var hmac = new HMACSHA512(user.passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.passwordHash[i]) return Unauthorized("Entered wrong Password");
            }

            /*  return Ok("hmac : " + hmac + " ; computeHash : " + computedHash);  */

            // Create Token
            return new AuthDTO
            {
                authId = user.id,
                token = _tokenService.CreateToken(user)
            };
        }


        // GET - Get User
        [Authorize]
        [HttpGet]
        public ActionResult<IList<AdminUser>> GetUser()
        {
            return _context.AdminUsers.ToList();
        }


        //  GET by ID - Get single user account
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminUser>> GetUserDetails(int id)
        {
            var user = await _context.AdminUsers.FirstOrDefaultAsync(x => x.id == id);    
            if (user == null)
            {
                return NotFound("Not Found");
            }
            return Ok(user);
        }


        // CHECK User Email Exist -:or:- Not
        private async Task<bool> ExistEmail(string? email)
        {
            return await _context.AdminUsers.AnyAsync(x => x.email == email);
        }

    }
}
