
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using renato_movie_store.Context;
using renato_movie_store.Context.Model;
using renato_movie_store.Filters;
using renato_movie_store.Models.OMDbModel;
using renato_movie_store.Util;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace renato_movie_store.Services
{
    public class OMDbAPIService
    {

        private readonly MovieStoreDbContext _movieStoreDbContext;
        public OMDbAPIService(MovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
        }


        public async Task<OMDbAPIFilter> GetMoviesByName(string name)
        {
            OMDbAPIFilter filter = null;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiKey = "69adc2cd";
                    string host = "http://www.omdbapi.com/?apikey=" + apiKey;

                    var response = await client.GetAsync($"{host}&t={name}");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        filter = JsonConvert.DeserializeObject<OMDbAPIFilter>(jsonString);

                    }
                    else
                    {
                        throw new BadRequestException("error host.", "OMDbAPI.https_error");
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return filter;
        }



        public async Task<OMDbAPIFilter> GetMoviesByImdb(string imdbID)
        {
            OMDbAPIFilter filter = null;

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string apiKey = "69adc2cd";
                    string host = "http://www.omdbapi.com/?apikey=" + apiKey;

                    var response = await client.GetAsync($"{host}&i={imdbID}");

                    if (response.IsSuccessStatusCode)
                    {
                        var jsonString = await response.Content.ReadAsStringAsync();
                        filter = JsonConvert.DeserializeObject<OMDbAPIFilter>(jsonString);

                    }
                    else
                    {
                        throw new BadRequestException("error host.", "OMDbAPI.https_error");
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return filter;
        }


        public async Task<RentHistory> CreateMovieRental(CreateOMDbRequestModel model, OMDbAPIFilter queryMovie)
        {

            var customer = _movieStoreDbContext.Customers.FirstOrDefault(x => x.CustomerId == model.CustomerId);

            if (customer != null)
            {
                if (customer.Age < 14)
                {
                    throw new ForbiddenException("user under 14 years old", "OMDbAPI.user_under_14_years_old");
                }

                var activeRentalsCount = _movieStoreDbContext.RentalHistories.Count(x => x.CustomerId == model.CustomerId && x.Status == RentStatusEnum.ACTIVE);

                if (activeRentalsCount >= 2)
                {
                    throw new ForbiddenException("maximum rentals reached", "OMDbAPI.maximum_rentals_reached");
                }

                //se o filme ja ta alugado
                var rentedMovie = _movieStoreDbContext.RentalHistories.Any(x => x.ImdbId == queryMovie.ImdbID && x.Status == RentStatusEnum.ACTIVE);

                if (rentedMovie)
                    throw new ForbiddenException("movie already rented", "OMDbAPI.movie_already_rented");

                var responseSerialize = JsonConvert.SerializeObject(queryMovie);

                var response = JsonConvert.DeserializeObject<OMDbAPIFilter>(responseSerialize);

                var rentHistory = new RentHistory();
                {
                    rentHistory.RentId = Guid.NewGuid();
                    rentHistory.ImdbId = response.ImdbID;
                    rentHistory.Title = response.Title;
                    rentHistory.Type = response.Type;
                    rentHistory.CustomerName = customer.CustomerName;
                    rentHistory.CreateDate = DateTime.UtcNow;
                    rentHistory.CustomerName = customer.CustomerName;
                    rentHistory.CPF = customer.CPF;
                    rentHistory.CustomerId = customer.CustomerId;
                    rentHistory.ExpireDate = model.ExpireDate;
                    rentHistory.Status = RentStatusEnum.ACTIVE;
                    _movieStoreDbContext.RentalHistories.Add(rentHistory);
                };

                if (customer.Status == CustomerStatusEnum.INACTIVE)
                {
                    customer.Status = CustomerStatusEnum.ACTIVE;
                }

                await _movieStoreDbContext.SaveChangesAsync();

                return rentHistory;
            }
            else
            {
                throw new BadRequestException("customer not exist", "OMDbAPI.customer_does_not_exist"); ;
            }
        }


        public async Task<List<RentHistory>> GetRentalsList()
        {
            var list = _movieStoreDbContext.RentalHistories.AsQueryable().OrderByDescending(x =>x.CreateDate);

            var queryList = await list.ToListAsync();
            return queryList;
        }



        public async Task DeleteRent(Guid rentId, Guid customerId)
        {
            var rent = await _movieStoreDbContext.RentalHistories.FirstOrDefaultAsync(x => x.RentId == rentId);

            if (rent == null)
                throw new BadRequestException("rent not exist", "OMDbAPI.rent_does_not_exist");



            _movieStoreDbContext.RentalHistories.Remove(rent);
            await _movieStoreDbContext.SaveChangesAsync();

            var customer = _movieStoreDbContext.RentalHistories.Any(x => x.CustomerId == customerId && x.Status == RentStatusEnum.ACTIVE);

            if (!customer)
            {
                var customerDisable = _movieStoreDbContext.Customers.FirstOrDefault(x => x.CustomerId == customerId);
                customerDisable.Status = CustomerStatusEnum.INACTIVE;

                await _movieStoreDbContext.SaveChangesAsync();
            }

        }

    }
}
