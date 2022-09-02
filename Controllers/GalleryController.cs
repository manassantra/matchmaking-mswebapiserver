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
        public async Task<ActionResult<ImageUploadDTO>> UploadImage(IList<IFormFile> formFile, int id)
        {
            try
            {
                var files = Request.Form.Files;
                var folderName = Path.Combine("StaticFiles", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var stringChars = new char[6];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }

                var randomBatchName = new String(stringChars);

                if (files.Any(f => f.Length == 0))
                {
                    return BadRequest();
                }
                foreach (var file in files)
                {

                    for (int i = 0; i < stringChars.Length; i++)
                    {
                        stringChars[i] = chars[random.Next(chars.Length)];
                    }

                    var randomName = new String(stringChars);
                    var fileName = "Img_" + randomName + "_" + ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                        var user = await _context.AppUsers.FirstOrDefaultAsync(x => x.id == id);
                        var gallery = new UserGallery
                        {
                            imageFilename = fileName,
                            imagePath = fullPath,
                            userRefid = user.id,
                            batchRefId = randomBatchName,
                            createdDate = DateTime.Now,
                            createdBy = user?.email,
                            isDeleted = false
                        };
                        _context.ImageGallery.Add(gallery);
                        await _context.SaveChangesAsync();

                        return new ImageUploadDTO
                        {
                            batchRefId = gallery.batchRefId,
                            userRefId = gallery.userRefid,
                        };
                    }
                }
               return Ok("All the files are successfully uploaded.");
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
        public ActionResult<IList<UserGallery>> GetUserGalleryDetails(int id)
        {
            var galleries = _context.ImageGallery.ToList();
            List<UserGallery> result = galleries.FindAll(x=> x.userRefid == id);
            return Ok(result);
        }


        [HttpGet("batch/{id}/{batchRefId}")]
        public ActionResult<IList<UserGallery>> GetGalleryByBatchId(int id, string batchRefId)
        {
            var galleries = _context.ImageGallery.ToList();
            List<UserGallery> result = galleries.FindAll(x => x.batchRefId == batchRefId && x.userRefid == id);
            return Ok(result);
        }
    }
}
