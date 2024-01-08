using Newtonsoft.Json;

namespace renato_movie_store.Models.OMDbModel
{
    public class DeleteOMDbRentalModel
    {

        [JsonProperty("custumerId")]
        public Guid CustomerId { get; set; }


        [JsonProperty("rentId")]
        public Guid RentId { get; set; }
    }
}
