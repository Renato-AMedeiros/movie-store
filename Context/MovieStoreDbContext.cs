using Microsoft.EntityFrameworkCore;
using renato_movie_store.Context.Model;

namespace renato_movie_store.Context
{
    public class MovieStoreDbContext : DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Login> Logins{ get; set; }
        public DbSet<Customer> Customers{ get; set; } 
        public DbSet<LoginInformation> LoginInformations{ get; set; } 
        public DbSet<RentHistory> RentalHistories{ get; set; } 

    }
}
