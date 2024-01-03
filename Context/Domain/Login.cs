using System.ComponentModel.DataAnnotations;

namespace renato_movie_store.Context.Model
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        public string? Email { get; set; }

        public string? CPF { get; set; }

        public string? Password { get; set; }
    }
}
