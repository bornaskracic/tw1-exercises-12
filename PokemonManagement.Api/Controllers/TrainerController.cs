using Microsoft.AspNetCore.Mvc;
using PokemonManagement.BL.Exceptions;
using PokemonManagement.BL.Interfaces;

namespace PokemonManagement.Api.Controllers
{
    [Route("api/trainers")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpPost("train/{trainerPokemonId}")]
        public ActionResult Train(int trainerPokemonId)
        {
            try
            {
                _trainerService.Train(trainerPokemonId);
                return Ok("level increased");
            } 
            catch (EntityNotFoundException) { return NotFound(); }
            catch (PokemonLogicException ex) { return BadRequest(ex.Message); } 

        }

        [HttpPost("evolve/{trainerPokemonId}")]
        public ActionResult Evolve([FromRoute] int trainerPokemonId)
        {
            
            // call trainerService method?

            return Ok(); // ?
        }
    }
}
