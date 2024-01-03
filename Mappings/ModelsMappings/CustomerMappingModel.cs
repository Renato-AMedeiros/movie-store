using Newtonsoft.Json;
using renato_movie_store.Util;

namespace renato_movie_store.Mappings.ModelsMappings
{
    public class CustomerMappingModel
    {
        [JsonProperty("customer_id")]
        public Guid CustomerId { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("genero")]
        public string Genero { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("cpf")]
        public string CPF { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        [JsonProperty("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonConverter(typeof(IsoDateConverter))]
        [JsonProperty("update_date")]
        public DateTime? UpdateDate { get; set; }
    }
}

