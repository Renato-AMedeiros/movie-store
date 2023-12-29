using Newtonsoft.Json;
using renato_movie_store.Util;

namespace renato_movie_store.Mappings.ModelsMappings
{
    public class RentHistoryMappingModel
    {
        [JsonProperty("rentId")]
        public string RentId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imdbId")]
        public string ImdbId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("cpf")]
        public int CPF { get; set; }

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
