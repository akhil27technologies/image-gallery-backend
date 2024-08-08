using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Gallery_Backend.Models;
using Gallery_Backend.Services;


namespace Gallery_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly MongoDBContext _context;

        public ImagesController(MongoDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Image>>> GetImages()
        {
            return await _context.Images.Find(img => true).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Image>> GetImage(string id)
        {
            var image = await _context.Images.Find(img => img.Id == id).FirstOrDefaultAsync();
            if (image == null)
            {
                return NotFound();
            }
            return image;
        }

        [HttpPost]
        public async Task<ActionResult<Image>> CreateImage([FromBody] Image image)
        {
            await _context.Images.InsertOneAsync(image);
            return CreatedAtAction(nameof(GetImage), new { id = image.Id }, image);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(string id)
        {
            var result = await _context.Images.DeleteOneAsync(img => img.Id == id);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
