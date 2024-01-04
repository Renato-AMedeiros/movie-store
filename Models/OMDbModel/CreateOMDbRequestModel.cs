using Newtonsoft.Json;
using renato_movie_store.Util;

namespace renato_movie_store.Models.OMDbModel
{
    public class CreateOMDbRequestModel
    {

        [JsonProperty("custumerId")]
        public Guid CustomerId { get; set; }

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

