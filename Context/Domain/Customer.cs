using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace renato_movie_store.Context.Model
{
    public class Customer
    {
        public Customer()
        {
            Rentals = new Collection<RentHistory>();
        }

        [Key]
        public string CustomerId { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(150)]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "O Genero é obrigatório.")]
        [StringLength(50)]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório.")]
        [StringLength(400)]
        public string Email { get; set; }

        [Required]
        public int Age { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [Range(0, 99999999999, ErrorMessage = "O CPF deve estar entre 0 e 99999999999.")]
        public int CPF { get; set; }


        public string Address { get; set; }


        public string City { get; set; }


        public string Country { get; set; }


        public int PhoneNumber { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }



        public ICollection<RentHistory>? Rentals { get; set; }
    }
}
