using Newtonsoft.Json;
using renato_movie_store.Util;

namespace renato_movie_store.Models.CustomerModel
{
    public class UpdateCustomerModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("genero")]
        public string Genero { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone_number")]
        public int PhoneNumber { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        [JsonProperty("update_date")]
        public DateTime? UpdateDate { get; set; }

    }
}
