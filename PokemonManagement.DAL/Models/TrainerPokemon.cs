namespace PokemonManagement.DAL.Models
{
    public class TrainerPokemon
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; } = null!;

        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; } = null!;

        public int Level { get; set; }
    }
}
