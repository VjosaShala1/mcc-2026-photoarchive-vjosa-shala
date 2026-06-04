using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhotoArchive.API.Data;
using PhotoArchive.API.Models;
using System.IO;
using System.Threading.Tasks;

namespace PhotoArchive.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PhotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllPhotos()
        {
            return Ok(_context.Photos.ToList());
        }

        [HttpGet("search/{tag}")]
        public IActionResult SearchByTag(string tag)
        {
            var photos = _context.Photos
                .Where(p => p.Tag == tag)
                .ToList();

            return Ok(photos);
        }

        [HttpPost]
        public IActionResult AddPhoto(Photo photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();

            return Ok(photo);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadPhoto(IFormFile file, string tag)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var uploadsFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Uploads");

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var filePath = Path.Combine(
                uploadsFolder,
                file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo
            {
                FileName = file.FileName,
                FilePath = filePath,
                Tag = tag,
                FileSize = file.Length,
                UploadedAt = DateTime.UtcNow
            };

            _context.Photos.Add(photo);
            _context.SaveChanges();

            return Ok(photo);
        }
    }
}