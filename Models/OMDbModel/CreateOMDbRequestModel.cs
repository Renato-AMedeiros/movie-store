using Newtonsoft.Json;
using renato_movie_store.Util;

namespace renato_movie_store.Models.OMDbModel
{
    public class CreateOMDbRequestModel
    {

        [JsonProperty("cpf")]
        public string? CPF{ get; set; }

        [JsonProperty("custumerId")]
        public Guid CustomerId { get; set; }

        [JsonProperty("customer_name")]
        public string? CustomerName { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("year")]
        public string Year { get; set; }

        [JsonProperty("rated")]
        public string Rated { get; set; }

        [JsonProperty("released")]
        public string Released { get; set; }

        [JsonProperty("runtime")]
        public string Runtime { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("director")]
        public string Director { get; set; }

        [JsonProperty("writer")]
        public string Writer { get; set; }

        [JsonProperty("actors")]
        public string Actors { get; set; }

        [JsonProperty("plot")]
        public string Plot { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("awards")]
        public string Awards { get; set; }

        [JsonProperty("poster")]
        public string Poster { get; set; }

        [JsonProperty("metascore")]
        public string Metascore { get; set; }

        [JsonProperty("imdbRating")]
        public string ImdbRating { get; set; }

        [JsonProperty("imdbVotes")]
        public string ImdbVotes { get; set; }

        [JsonProperty("imdbID")]
        public string ImdbID { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("totalSeasons")]
        public string TotalSeasons { get; set; }

        [JsonProperty("response")]
        public string Response { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        [JsonProperty("update_date")]
        public DateTime? UpdateDate { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        [JsonProperty("expire_date")]
        public DateTime? ExpireDate { get; set; }
    }


}

