using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mswebapiserver.DTOs;
using mswebapiserver.Interfaces;
using mswebapiserver.Models;
using System.Security.Cryptography;
using System.Text;

namespace mswebapiserver.Controllers
{
    public class UserAccountController : BaseapiController
    {
        private readonly DatabaseContext _context;
        private readonly ITokenService _tokenService;

        public UserAccountController(DatabaseContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }


        //  POST - Create User Account
        [HttpPost("create")]
        public async Task<ActionResult<AuthDTO>>  CreateUser(AppuserDTO appuser)
        {
            if (await ExistEmail(appuser.email)) return BadRequest("User Allready exist with this Email !");
            else if (await ExistMobile(appuser.mobile)) return BadRequest("Mobile number is already used in another Account !");

            var chars = "0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                uid = "MM" + finalString,
                firstName = appuser.firstName,
                lastName = appuser.lastName,
                fullName = appuser.firstName + " " + appuser.lastName,  
                email = appuser.email,
                mobile = appuser.mobile,
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(appuser.password)),
                passwordSalt = hmac.Key,
                gender = appuser.gender,
                agentId = appuser.agentId,
                isActive = true,
                isPremium = false,
                createdDate = DateTime.Now,
                modifiedDate = DateTime.Now,
                modifiedBy = null
            };

            _context.AppUsers.Add(user);
            await _context.SaveChangesAsync();

            return new AuthDTO
            {
                authId = user.id,
                token = _tokenService.CreateToken(user),
            };
        }


        //  POST - Login / Authenticate User
        [HttpPost("login")]
        public async Task<ActionResult<AuthDTO>> Login(LoginDTO loginDto)
        {
            var user = await _context.AppUsers
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

            // Create Token
            return new AuthDTO
            {
                authId = user.id,
                token = _tokenService.CreateToken(user)
            };
        }


        //  GET - Get All Users
        [HttpGet]
        [Authorize]
        public ActionResult<IList<AppUser>> GetAllUser()
        {
            return _context.AppUsers.ToList();
        }



        //  GET by ID - Get single user account
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUserDetails(int id)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == id);
            if (user == null)
            {
                return NotFound("Not Found");
            }
            return Ok(user);
        }



        // PUT - Update user by Id
        [Authorize]
        [HttpPut("update/{id}")]
        public async Task<ActionResult<AppuserDTO>>  UpdateUser(int id, AppuserDTO appuser)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.id == id);

            if (user == null) return NotFound("Invalid Operation !");

            user.firstName = appuser.firstName;
            user.lastName = appuser.lastName;
            user.email = appuser.email;
            user.mobile = appuser.mobile;
            user.gender = appuser.gender;
            user.agentId = appuser.agentId;
            user.modifiedDate = DateTime.Now;
            user.modifiedBy = user.email;

            _context.AppUsers.Update(user);
            await _context.SaveChangesAsync();

            return Ok("Data Updated Successfully !");
        }



        // DELETE - Delete User Account
        [Authorize]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<AppUser>> DeleteAccount(int id)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.id == id);
            _context.AppUsers.Remove(user);
            await _context.SaveChangesAsync();
            return Ok("User Deleted Successfully !");
        }


        private async Task<bool> ExistEmail(string? email)
        {
            return await _context.AppUsers.AnyAsync(x => x.email == email);
        }
        private async Task<bool> ExistMobile(Int64 mob)
        {
            return await _context.AppUsers.AnyAsync(x => x.mobile == mob);
        }
    }
}
