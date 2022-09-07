using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mswebapiserver.DTOs;
using mswebapiserver.Models;
using System.Linq;
using System.Net.Http.Headers;


namespace mswebapiserver.Controllers
{

    public class GalleryController : BaseapiController
    {
        private readonly DatabaseContext _context;
        public GalleryController(DatabaseContext context)
        {
            _context = context;
        }


        //  POST  ::  Uploade Images
        [HttpPost("upload/{id}")]
        public async Task<ActionResult<UserGalleryDTO>> UploadImage(IList<IFormFile> formFile, int id)
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }

                var chars = "0123456789";
                var stringChars = new char[6];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var randomId = new String(stringChars);

                var userGallery = new List<UserGalleryDTO>();
                foreach (var file in files)
                {
                    var chars2 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
                    var stringChars2 = new char[8];
                    var random2 = new Random();

                    for (int i = 0; i < stringChars2.Length; i++)
                    {
                        stringChars2[i] = chars2[random2.Next(chars2.Length)];
                    }

                    var randomName = new String(stringChars2);
                    var fileName = "Img_" + randomName + ".jpg";
                    var fullPath = Path.Combine(pathToSave, fileName);

                  //  var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == id);
                    var gallery = new UserGallery
                    {
                        imageFilename = fileName,
                        imagePath = fullPath,
                        userRefid = user.id,
                        postBatchId = Int32.Parse(randomId),
                        createdDate = DateTime.Now,
                        createdBy = user?.email,
                        isDeleted = false
                    };

                    _context.ImageGallery.Add(gallery);
                    await _context.SaveChangesAsync();
                    var usergal = new UserGalleryDTO
                    {
                        uid = user.id,
                        postBatchId = gallery.postBatchId,
                        fileName = gallery.imageFilename
                    };

                    userGallery.Add(usergal);
                }
                return Ok(userGallery);
            } catch (Exception ex)
            {
                return StatusCode(500, "Internal server error; \n" + ex);
            }
        }


        [HttpGet]
        public ActionResult<IList<UserGallery>> GetAll()
        {
            return _context.ImageGallery.ToList();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserGallery>> GetUserGalleryDetails(int id)
        {
            var image = await _context.ImageGallery.FirstOrDefaultAsync(x => x.userRefid == id);
            return Ok(image);
        }
    }
}
