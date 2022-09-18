using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mswebapiserver.DTOs;
using mswebapiserver.Models.User;

namespace mswebapiserver.Controllers
{
    public class UserReligionsController : BaseapiController
    {
        private readonly DatabaseContext _context;

        public UserReligionsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<UserReligionDTO>> CreateReligionDetails(int id, UserReligionDTO userReligion)
        {
            var user = _context.AppUsers.FirstOrDefault(x => x.id == id);
            if (await ExistUserReligionDetails(id)) return BadRequest("User Religion Details Already Exist !");

            var details = new UserReligion
            {
                userRefId = user.id,
                religion = userReligion.religion,
                community = userReligion.community,
                subCommunity = userReligion.subCommunity,
                gothra = userReligion.gothra,
                modifiedDate = DateTime.Now,
                modifiedBy = user.email,
                isActive = true
            };

            _context.UserReligions.Add(details);
            await _context.SaveChangesAsync();

            return Ok("User Religion Details Created Successfully !");
        }


        [HttpGet("{id}")]
        public ActionResult FindUserReligionDetails(int id)
        {
            var religionDetails = _context.UserReligions.FirstOrDefault(x => x.userRefId == id && x.isActive == true);
            if (religionDetails == null) return BadRequest("No Active Details Found !");
            return Ok(religionDetails);
        }

        private async Task<bool> ExistUserReligionDetails(int id)
        {
            return await _context.UserReligions.AnyAsync(x => x.userRefId == id && x.isActive == true);
        }
    }
}
