using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mswebapiserver.DTOs;
using mswebapiserver.Interfaces;
using mswebapiserver.Models;
using System.Net.Http.Headers;

namespace mswebapiserver.Controllers
{

    public class ProfilepicController : BaseapiController
    {
        private readonly DatabaseContext _context;

        public ProfilepicController(DatabaseContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public ActionResult GetImage(int id)
        {
            var image = _context.ProfilePictures.FirstOrDefault(x => x.userRefid == id);
            return Ok(image);
        }


        [HttpPost("create/{id}")]
        public async Task<ActionResult> CreateProfilePic(IFormFile fromFile, int id)
        {
            var user = _context.AppUsers.FirstOrDefault(x=> x.id == id);
            if (user == null) return BadRequest();

            /* ------- Image Saving Logic Implementation  --------- */

            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                foreach (var file in files)
                {
                    var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
                    var stringChars = new char[8];
                    var random = new Random();

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var randomName = new String(stringChars);

                    var fileName = "Img_" + randomName + ".jpg";
                    var fullPath = Path.Combine(pathToSave, fileName);

                    //  var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var profilePic = new ProfilePicture
                    {
                        imageFilename = fileName,
                        imagePath = fullPath,
                        userRefid = user.id,
                        createdDate = DateTime.Now,
                        createdBy = user?.email,
                        isDeleted = false
                    };

                    _context.ProfilePictures.Add(profilePic);
                    await _context.SaveChangesAsync();
                    return Ok(profilePic);
                }
                return Ok("Profile Picture Uploaded Successfully !");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error; \n" + ex);
            }

            /*  ------------ End --------------- */
        }
    }
}
