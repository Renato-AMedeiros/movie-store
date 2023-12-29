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
        
        
        [HttpGet("rent/{customerId}")]

        public async Task<IActionResult> GetRentalsList([FromRoute] RentHistoryFilter filter, string customerId)
        {
            var rentalList = await _oMDbAPIService.GetRentalsList(filter, customerId);

            var response =  rentalList.Select(RentHistoryMapping.RentHistoryMap).ToList();

            return Ok(rentalList);
        }





        [HttpPost("{imdbID}")]
        public async Task<IActionResult> CreateMovieRental([FromRoute] string imdbID, [FromBody] CreateOMDbRequestModel model)
        {
            var queryMovie = await _oMDbAPIService.GetMoviesByImdb(imdbID);

            var request = await _oMDbAPIService.CreateMovieRental(model, queryMovie);

            return Ok(request);
        }



        [HttpDelete("rent/{rentId}")]

        public async Task<IActionResult> DeleteRent([FromRoute] string rentId)
        {

            await _oMDbAPIService.DeleteRent(rentId);

            return NoContent();
        }




    }
}
