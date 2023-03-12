using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreApp.Models;
using System.Reflection.Metadata;

namespace ASPNetCoreApp.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : Controller
    {
        private readonly GamingPlatform _context;

        public GamesController(GamingPlatform context)
        {
            _context = context;
            if (_context.Game.Count() == 0)
            {
                _context.Game.Add(new Game
                {
                    Name = "Elden Ring",
                    Mode = "online",
                    Genre = "экшен",
                    Price = 3500,
                    Developer = " ",
                    Description = " ",
                    RegistrationDate = DateTime.Now,
                    ReleaseDate = DateTime.Now,
                    ImageLink = "EldenRing.ru",
                    Rating = 5,
                    NumberRatings = 105
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Game> GetAll()
        {
            return _context.Game;
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
        public async Task<IActionResult> Create([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Game.Add(game);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Game game)
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
            item.Genre = game.Genre;
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
