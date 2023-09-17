using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microgame.Models;

namespace microgame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly GameContext _context;

        public PlayersController(GameContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
          if (_context.Players == null)
          {
              return NotFound();
          }
            return await _context.Players
                .Include(player => player.Weapon)
                .Include(player => player.Armor)
                .ToListAsync();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(long id)
        {
          if (_context.Players == null)
          {
              return NotFound();
          }
            var player = await _context.Players
                .Include(player => player.Weapon)
                .Include(player => player.Armor)
                .FirstOrDefaultAsync(player => player.Id == id);


            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayer(long id, Player player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }

            _context.Entry(player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Players
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Player>> PostPlayer(Player player)
        {
          if (_context.Players == null)
          {
              return Problem("Entity set 'GameContext.Players'  is null.");
          }
            _context.Players.Add(player);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(long id)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{id}/status")]
        public async Task<ActionResult<string>> GetPlayerStatus(long id)
        {
            if (_context.Players == null)
            {
                return NotFound();
            }
            var player = await _context.Players
                .Include(player => player.Weapon)
                .Include(player => player.Armor)
                .FirstOrDefaultAsync(player => player.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return player.getCurrentHP();
        }

        [HttpGet("{id}/attackedby/{enemyId}")]
        public async Task<ActionResult<String>> GetAttackedBy(long id, long enemyId)
        {

            var player = await _context.Players.FindAsync(id);
            var enemy = await _context.Enemies.FindAsync(enemyId);

            if (player == null)
            {
                return NotFound("Player not found.");
            }
            if (enemy == null)
            {
                return NotFound("Enemy not found.");
            }
            if (player.isDead()) {
                return NotFound(player.Name+" is dead already.");
            }

            var damage = enemy.AttackPoint - player.getDP();
            if (damage>0) {
                player.getAttacked(damage);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine(ex.InnerException?.Message);
                    return Problem(ex.InnerException?.Message);
                }
                return "[+]" + player.Name + " attacked by " + enemy.Name +" Damage: "+damage;
            } else {
                return "[+] "+player.Name+" attacked by "+enemy.Name+" : no effect!";
            }
        }

        [HttpGet("{id}/equipweapon/{equipmentId}")]
        public async Task<ActionResult<String>> EquipWeapon(long id, long equipmentId)
        {

            var player = await _context.Players.FindAsync(id);
            var equipment = await _context.Equipments.FindAsync(equipmentId);

            if (player == null)
            {
                return NotFound("Player not found.");
            }
            if (equipment == null)
            {
                return NotFound("Equipment not found.");
            }

            player.equipWeapon(equipment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return Problem(ex.InnerException?.Message);
            }
            return "[+]" + player.Name + " equip " + equipment.Name + " Current AP: " + player.getAP();
        }

        [HttpGet("{id}/equiparmor/{equipmentId}")]
        public async Task<ActionResult<String>> EquipArmor(long id, long equipmentId)
        {

            var player = await _context.Players.FindAsync(id);
            var equipment = await _context.Equipments.FindAsync(equipmentId);

            if (player == null)
            {
                return NotFound("Player not found.");
            }
            if (equipment == null)
            {
                return NotFound("Equipment not found.");
            }

            player.equipArmor(equipment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                return Problem(ex.InnerException?.Message);
            }
            return "[+]" + player.Name + " equip " + equipment.Name + " Current DP: " + player.getDP();
        }

        private bool PlayerExists(long id)
        {
            return (_context.Players?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
