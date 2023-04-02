using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreApp.Controllers
{
    [Route("api/genres")]
    [EnableCors]
    [ApiController]
    public class GenresController : Controller
    {
        private readonly GamingPlatform _context;

        public GenresController(GamingPlatform context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetAll()
        {
            return await _context.Genres.ToListAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Genres.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Genres.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
