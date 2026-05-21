using Microsoft.EntityFrameworkCore;
using PokemonManagement.BL.Interfaces;
using PokemonManagement.BL.Services;
using PokemonManagement.DAL.Db;
using PokemonManagement.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Controller[action] -> Service -> Repository -> PokemonDbContext

// required for repository
builder.Services.AddDbContext<PokemonDbContext>(
    opts => opts.UseSqlServer("Name=ConnectionStrings:Default"));

// required for service
builder.Services.AddScoped<ITrainerPokemonRepository, TrainerPokemonRepository>();

// required for controller's action
builder.Services.AddScoped<ITrainerService, TrainerService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PokemonDbContext>();
    context.Database.EnsureCreated();
    DbSeederHelper.Seed(context);
}

app.MapControllers();

app.Run();
