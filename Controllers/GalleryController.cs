using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mswebapiserver.DTOs;
using mswebapiserver.Models;
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
        public async Task<IActionResult> UploadImage(IFormFile formFile, int id)
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
                foreach (var file in files)
                {

                    var fileName = "Img_" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);

                  //  var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == id);
                        var gallery = new UserGallery
                        {
                            imageFilename = fileName,
                            imagePath = fullPath,
                            userRefid = user.id,
                            createdDate = DateTime.Now,
                            createdBy = user?.email,
                            isDeleted = false
                        };
                        _context.ImageGallery.Add(gallery);
                        await _context.SaveChangesAsync();

                        return Ok("Image Uploaded Successfully!");
                    }
                }
               return Ok();
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
