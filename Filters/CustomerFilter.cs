namespace renato_movie_store.Filters
{
    public class CustomerFilter
    {
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Genero { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
