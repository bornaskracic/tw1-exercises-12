using PokemonManagement.DAL.Models;
namespace PokemonManagement.DAL.Repositories
{
    public interface ITrainerPokemonRepository
    {
        public TrainerPokemon? GetBy(int id);
        public void Update(TrainerPokemon updated);
    }
}
