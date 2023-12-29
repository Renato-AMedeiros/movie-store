﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.SecurityTokenService;
using Newtonsoft.Json;
using renato_movie_store.Context;
using renato_movie_store.Context.Model;
using renato_movie_store.Filters;
using renato_movie_store.Models.OMDbModel;
using System.Collections.Generic;
using System.Text.Json.Nodes;
using System.Xml.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                        throw new BadRequestException("error host.");
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
                        throw new BadRequestException("error host.");
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
                var responseSerialize = JsonConvert.SerializeObject(queryMovie);
                var response = JsonConvert.DeserializeObject<OMDbAPIFilter>(responseSerialize);

                var rentHisotory = new RentHistory
                {
                    ImdbId = response.ImdbID,
                    Title = response.Title,
                    Type = response.Type
                };

                rentHisotory.RentId = model.RentId;
                rentHisotory.Name = model.Name;
                rentHisotory.CreateDate = DateTime.UtcNow;
                rentHisotory.Name = model.Name;
                rentHisotory.CPF = model.CPF;
                rentHisotory.CustomerId = model.CustomerId;
                rentHisotory.ExpireDate = model.ExpireDate;

                _movieStoreDbContext.RentalHistories.Add(rentHisotory);
                await _movieStoreDbContext.SaveChangesAsync();

                return rentHisotory;
            }
            else
            {
                throw new BadRequestException("customer not exist"); ;
            }
        }


        public async Task<List<RentHistory>> GetRentalsList(RentHistoryFilter filter, string customerId)
        {
            var customer = _movieStoreDbContext.Customers.FirstOrDefault(x => x.CustomerId == customerId);

            var list = _movieStoreDbContext.RentalHistories.AsQueryable();

            if (customer != null)
            {

                if (!string.IsNullOrEmpty(filter.Name))
                {
                    list = list.Where(x => x.Title == filter.Title);
                }

                if (!string.IsNullOrEmpty(filter.Title))
                {
                    list = list.Where(x => x.Title == filter.Title);
                }

                if (!string.IsNullOrEmpty(filter.Type))
                {
                    list = list.Where(x => x.Type == filter.Type);
                }

                if (!string.IsNullOrEmpty(filter.CustomerId))
                {
                    list = list.Where(x => x.CustomerId == filter.CustomerId);
                }

                if (!string.IsNullOrEmpty(filter.CreateDate.ToString()))
                {
                    list = list.Where(x => x.CreateDate == filter.CreateDate);
                }

                if (!string.IsNullOrEmpty(filter.ExpireDate.ToString()))
                {
                    list = list.Where(x => x.ExpireDate == filter.ExpireDate);
                }
            }

            var queryList = await list.ToListAsync();
            return queryList;
        }



        public async Task DeleteRent(string rentId)
        {
            var rent = await _movieStoreDbContext.RentalHistories.FirstOrDefaultAsync(x => x.RentId == rentId);

            if (rent != null)
                throw new BadRequestException("rent not exist");

            _movieStoreDbContext.RentalHistories.Remove(rent);
            await _movieStoreDbContext.SaveChangesAsync();

  

        }

    }
}
