using System.ComponentModel.DataAnnotations;

namespace renato_movie_store.Context.Model
{
    public class RentHistory
    {

        [Key]
        public string RentId { get; set; }

        public string Status { get; set; }

        public string CustomerName { get; set; }

        public string ImdbId { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public int CPF { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? ExpireDate { get; set; }




        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
