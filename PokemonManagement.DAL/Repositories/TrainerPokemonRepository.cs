using PokemonManagement.DAL.Db;
using PokemonManagement.DAL.Models;

namespace PokemonManagement.DAL.Repositories
{
    public class TrainerPokemonRepository : ITrainerPokemonRepository
    {

        private readonly PokemonDbContext _context;

        public TrainerPokemonRepository(PokemonDbContext context)
        {
            _context = context;
        }

        public TrainerPokemon? GetBy(int id)
        {
            return _context.TrainerPokemons.Find(id);
        }

        public void Update(TrainerPokemon updated)
        {
            _context.SaveChanges();
        }
    }
}
