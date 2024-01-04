using Microsoft.AspNetCore.Mvc;
using renato_movie_store.Context.Model;
using renato_movie_store.Filters;
using renato_movie_store.Mappings;
using renato_movie_store.Models.OMDbModel;
using renato_movie_store.Services;

namespace renato_movie_store.Controllers
{
    [Route("v1/OMDbApi")]
    [ApiController]
    public class OMDbAPIController : ControllerBase
    {
        private readonly OMDbAPIService _oMDbAPIService;
        public OMDbAPIController(OMDbAPIService oMDbAPIService)
        {
            _oMDbAPIService = oMDbAPIService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetMoviesByName([FromRoute] string name)
        {
            var movieList = await _oMDbAPIService.GetMoviesByName(name);

            return Ok(movieList);
        }      
        
        
        [HttpGet("rentals")]

        public async Task<IActionResult> GetRentalsList()
        {
            var rentalList = await _oMDbAPIService.GetRentalsList();

            var response =  rentalList.Select(RentHistoryMapping.RentHistoryMap).ToList();

            return Ok(rentalList);
        }





        [HttpPost("{imdbId}")]
        public async Task<IActionResult> CreateMovieRental([FromRoute] string imdbID, [FromBody] CreateOMDbRequestModel model)
        {
            var queryMovie = await _oMDbAPIService.GetMoviesByImdb(imdbID);

            var request = await _oMDbAPIService.CreateMovieRental(model, queryMovie);

            var result = RentHistoryMapping.RentHistoryMap(request);

            return Ok(result);
        }



        [HttpDelete("rent/{rentId}/{customerId}")]

        public async Task<IActionResult> DeleteRent([FromRoute] Guid rentId, Guid customerId)
        {

            await _oMDbAPIService.DeleteRent(rentId, customerId);

            return NoContent();
        }




    }
}
