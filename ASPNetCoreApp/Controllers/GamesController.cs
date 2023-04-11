using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreApp.Models;

using Microsoft.AspNetCore.Cors;
using ASPNetCoreApp.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ASPNetCoreApp.Controllers
{
    [Route("api/games")]
    [EnableCors]
    [ApiController]
    public class GamesController : Controller
    {
        private readonly GamingPlatform _context;

        public GamesController(GamingPlatform context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetAll()
        {
            return await _context.Game.Include(i => i.Genre).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var game = await _context.Game.SingleOrDefaultAsync(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GameDTO game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Game g = new Game
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Mode = game.Mode,
                ReleaseDate = game.ReleaseDate,
                Price = game.Price,
                Developer = game.Developer,
                RegistrationDate = game.RegistrationDate,
                ImageLink = game.ImageLink,
                Description = game.Description,
                Rating = game.Rating,
                NumberRatings = game.NumberRatings,
                Genre = _context.Genres.Find(game.GenreId)
            };

            _context.Game.Add(g);
            _context.SaveChanges();
            return CreatedAtAction("GetGame", new { id = g.Id }, g);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] GameDTO game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Game.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            item.Name = game.Name;
            item.Description = game.Description;
            item.Mode = game.Mode;
            item.Genre = _context.Genres.Find(game.GenreId);
            item.Price = game.Price;
            item.Developer = game.Developer;
            item.RegistrationDate = game.RegistrationDate;
            item.ReleaseDate = game.ReleaseDate;
            item.ImageLink = game.ImageLink;
            item.Rating = game.Rating;
            item.NumberRatings = game.NumberRatings;

            _context.Game.Update(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.Game.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.Game.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
