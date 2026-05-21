namespace PokemonManagement.DAL.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? EvolvesToId { get; set; }
        public Pokemon? EvolvesTo { get; set; }
    }
}
