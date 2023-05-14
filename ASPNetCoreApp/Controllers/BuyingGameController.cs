using ASPNetCoreApp.DTO;
using ASPNetCoreApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ASPNetCoreApp.Controllers
{
    [Route("api/buyingGame")]
    [EnableCors]
    [ApiController]
    public class BuyingGameController : Controller
    {
        private readonly GamingPlatform _context;

        public BuyingGameController(GamingPlatform context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyingGame>>> GetBuyingGames()
        {
            return await _context.BuyingGames.Include(i => i.Game).Include(i => i.User).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<BuyingGame>>> GetBuyingGame([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _context.BuyingGames.Include(i => i.Game).Include(i => i.User).Where(i => i.UserId == id).ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BuyingGameDTO buying)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            BuyingGame b = new BuyingGame
            {
                GameId = buying.GameId,
                UserId = buying.UserId,
                PurchaseDate = buying.PurchaseDate,
                PurchasePrice = buying.PurchasePrice,
                Game = _context.Game.Find(buying.GameId),
                User = _context.Users.Find(buying.UserId)
            };

            _context.BuyingGames.Add(b);
            _context.SaveChanges();
            return CreatedAtAction("GetBuyingGame", new { id = b.Id }, b);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _context.BuyingGames.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            _context.BuyingGames.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
