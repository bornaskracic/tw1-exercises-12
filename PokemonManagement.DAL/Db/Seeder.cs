using PokemonManagement.DAL.Models;
namespace PokemonManagement.DAL.Db
{
    public static class DbSeederHelper
    {
        public static void Seed(PokemonDbContext context)
        {
            if (context.Pokemons.Any()) return; // if there are pokemons in the database, fail

            var venusaur = new Pokemon { Name = "Venusaur" };
            var ivysaur = new Pokemon { Name = "Ivysaur", EvolvesTo = venusaur };
            var bulbasaur = new Pokemon { Name = "Bulbasaur", EvolvesTo = ivysaur };

            var charizard = new Pokemon { Name = "Charizard" };
            var charmeleon = new Pokemon { Name = "Charmeleon", EvolvesTo = charizard };
            var charmander = new Pokemon { Name = "Charmander", EvolvesTo = charmeleon };

            var blastoise = new Pokemon { Name = "Blastoise" };
            var wartortle = new Pokemon { Name = "Wartortle", EvolvesTo = blastoise };
            var squirtle = new Pokemon { Name = "Squirtle", EvolvesTo = wartortle };

            context.Pokemons.AddRange(bulbasaur, ivysaur, venusaur,
                                  charmander, charmeleon, charizard,
                                  squirtle, wartortle, blastoise);

            context.SaveChanges();
        }
    }
}
