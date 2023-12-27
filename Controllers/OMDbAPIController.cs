using Microsoft.AspNetCore.Mvc;
using renato_movie_store.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        [HttpGet]
        public async Task<IActionResult> GetMoviesByName([FromRoute] string name)
        {
            var movieList = _oMDbAPIService.GetMoviesByName(name);

            return Ok(movieList);
        }















        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
