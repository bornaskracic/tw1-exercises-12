using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonManagement.DAL.Db;
using PokemonManagement.DAL.Models;

namespace PokemonManagement.Api.Controllers
{
    [Route("api/pokemons")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonDbContext _context;

        public PokemonController(PokemonDbContext db)
        {
            _context = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Pokemons.ToListAsync());

        [HttpPost]
        public async Task<IActionResult> Create(Pokemon p)
        {
            _context.Pokemons.Add(p);
            await _context.SaveChangesAsync();
            return Ok(p);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Pokemon updated)
        {
            var p = await _context.Pokemons.FindAsync(id);
            if (p == null) return NotFound();

            p.Name = updated.Name;
            p.EvolvesToId = updated.EvolvesToId;

            await _context.SaveChangesAsync();
            return Ok(p);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await _context.Pokemons.FindAsync(id);
            if (p == null) return NotFound();

            _context.Pokemons.Remove(p);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
