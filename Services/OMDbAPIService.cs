using Newtonsoft.Json;
using renato_movie_store.Context.Model;
using renato_movie_store.Filters;
using static System.Net.WebRequestMethods;

namespace renato_movie_store.Services
{
    public class OMDbAPIService
    {
        static string host = "https://www.omdbapi.com/?apikey=69adc2cd";

        public async Task<OMDbAPIFilter> GetMoviesByName(string name)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync($"{host}&t={name}");
            var jsonString = await response.Content.ReadAsStringAsync();

            var jasonObject = JsonConvert.DeserializeObject<OMDbAPIFilter>(jsonString);

            return jasonObject;
        }
    }
}
