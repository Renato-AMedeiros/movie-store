using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace renato_movie_store.Context.Model
{
    public class RentHistory
    {

        [Key]
        public Guid RentId { get; set; }

        public string Status { get; set; }

        public string CustomerName { get; set; }

        public string ImdbId { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string CPF { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? ExpireDate { get; set; }
        



        public Guid CustomerId { get; set; }

        [JsonIgnore]
        public virtual Customer? Customer { get; set; }
        
    }
}
