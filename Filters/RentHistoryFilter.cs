using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace renato_movie_store.Filters
{
    public class RentHistoryFilter
    {
        public string RentId { get; set; }

        [FromQuery(Name = "status")]
        public string Status { get; set; }

        public string Name { get; set; }

        public string ImdbId { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public string CustomerId { get; set; }

        public int CPF { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? ExpireDate { get; set; }
    }
}
