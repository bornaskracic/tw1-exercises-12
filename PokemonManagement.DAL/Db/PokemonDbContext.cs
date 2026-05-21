using Microsoft.EntityFrameworkCore;
using PokemonManagement.DAL.Models;

namespace PokemonManagement.DAL.Db
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<TrainerPokemon> TrainerPokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.EvolvesTo)
                .WithMany()
                .HasForeignKey(p => p.EvolvesToId);

            modelBuilder.Entity<TrainerPokemon>()
                .HasOne(tp => tp.Trainer)
                .WithMany(t => t.Pokemons)
                .HasForeignKey(tp => tp.TrainerId);

            modelBuilder.Entity<TrainerPokemon>()
                .HasOne(tp => tp.Pokemon)
                .WithMany()
                .HasForeignKey(tp => tp.PokemonId);
        }
    }
}
