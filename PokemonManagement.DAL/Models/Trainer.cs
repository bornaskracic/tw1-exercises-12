namespace PokemonManagement.DAL.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Candies { get; set; }
        public List<TrainerPokemon> Pokemons { get; set; } = new();
    }
}
