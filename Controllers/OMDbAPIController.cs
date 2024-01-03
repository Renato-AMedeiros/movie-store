using Microsoft.AspNetCore.Mvc;
using renato_movie_store.Context.Model;
using renato_movie_store.Filters;
using renato_movie_store.Mappings;
using renato_movie_store.Models.OMDbModel;
using renato_movie_store.Models.Services;

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

        public async Task<IActionResult> GetRentalsList([FromRoute] RentHistoryFilter filter, Guid customerId)
        {
            var rentalList = await _oMDbAPIService.GetRentalsList(filter, customerId);

            var response =  rentalList.Select(RentHistoryMapping.RentHistoryMap).ToList();

            return Ok(rentalList);
        }



        //[HttpPost("{imdbID}")]
        //public async Task<IActionResult> CreateMovieRental([FromRoute] string imdbID, [FromBody] CreateOMDbRequestModel model)
        //{
        //    try
        //    {
        //        var queryMovie = await _oMDbAPIService.GetMoviesByImdb(imdbID);
        //        var request = await _oMDbAPIService.CreateMovieRental(model, queryMovie);

        //        // Configura o cabeçalho Content-Type para application/json
        //        Response.Headers.Add("Accept", "application/json");


        //        // Retorna um objeto serializado como JSON
        //        return Ok(request);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Em caso de erro, você pode retornar uma resposta de erro adequada
        //        return BadRequest(new { error = ex.Message });
        //    }
        //}


        [HttpPost("{imdbID}")]
        public async Task<IActionResult> CreateMovieRental([FromRoute] string imdbID, [FromBody] CreateOMDbRequestModel model)
        {
            var queryMovie = await _oMDbAPIService.GetMoviesByImdb(imdbID);

            var request = await _oMDbAPIService.CreateMovieRental(model, queryMovie);

            return Ok(request);
        }



        [HttpDelete("rent/{rentId}")]

        public async Task<IActionResult> DeleteRent([FromRoute] Guid rentId)
        {

            await _oMDbAPIService.DeleteRent(rentId);

            return NoContent();
        }




    }
}
