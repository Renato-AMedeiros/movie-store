using Microsoft.EntityFrameworkCore;
using renato_movie_store.Context;
using renato_movie_store.Context.Model;
using renato_movie_store.Models.CustomerModel;
using renato_movie_store.Util;

namespace renato_movie_store.Services
{
    public class CustomerService
    {
        private readonly MovieStoreDbContext _movieStoreDbContext;
        public CustomerService(MovieStoreDbContext movieStoreDbContext)
        {
            _movieStoreDbContext = movieStoreDbContext;
        }

        public async Task<Customer> CreateCustomer(CreateCustomerRequestModel model)
        {

            var validEmail = _movieStoreDbContext.Customers.Any(x => x.Email == model.Email);
            var validCPF = _movieStoreDbContext.Customers.Any(x => x.CPF == model.CPF);

            if (validEmail)
                throw new ConflictException("email already exists.", "customer.email_already_registered");

            if (validCPF)
                throw new ConflictException("CPF already exists.", "customer.CPF_already_registered");

            var customer = new Customer()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = model.CustomerName,
                Gender = model.Gender,
                Email = model.Email,
                Age = model.Age,
                CPF = model.CPF,
                Address = model.Address,
                City = model.City,
                Country = model.Country,
                PhoneNumber = model.PhoneNumber,
                CreateDate = DateTime.UtcNow,
                Status = RentStatusEnum.INACTIVE
            };

            _movieStoreDbContext.Customers.Add(customer);
            await _movieStoreDbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<List<Customer>> GetCustomersList()
        {
            var query = _movieStoreDbContext.Customers.AsQueryable().OrderByDescending(x => x.CreateDate);

            var customers = await query.ToListAsync();
            return customers;
        }

        public Customer GetCustomerById(Guid customerId)
        {
            var query = _movieStoreDbContext.Customers.FirstOrDefault(x => x.CustomerId == customerId);

            if (query == null)
                throw new BadRequestException("customer is inactive", "customer.is_inactive");

            return query;
        }

        public async Task<List<Customer>> GetCustomersByName(string customerName, bool searchByInitial = false)
        {
            // Converte o nome para minúsculas para garantir uma comparação de string sem distinção entre maiúsculas e minúsculas
            var searchName = customerName.ToLower();

            var query = _movieStoreDbContext.Customers.AsQueryable();

            if (searchByInitial)
            {
                // Se estiver procurando por inicial, filtre com base na inicial do nome
                query = query.Where(x => x.CustomerName.ToLower().StartsWith(searchName));
            }
            else
            {
                // Se estiver procurando por nome completo, filtre com base no nome completo
                query = query.Where(x => x.CustomerName.ToLower().Contains(searchName));
            }

            var customers = await query.ToListAsync();

            if (customers.Count == 0)
            {
                throw new BadRequestException("No customers found with the specified name.", "customers.does_not_existed");
            }

            return customers;
        }

        public async Task<Customer> UpdateCustomer(UpdateCustomerRequestModel model, Guid customerId)
        {
            var customer = GetCustomerById(customerId);

            if (model != null)
            {
                if (!string.IsNullOrEmpty(model.CustomerName))
                    customer.CustomerName = model.CustomerName;

                if (!string.IsNullOrEmpty(model.Gender))
                    customer.Gender = model.Gender;

                if (!string.IsNullOrEmpty(model.Email))
                {
                    var validEmail = _movieStoreDbContext.Customers.Any(x => x.Email == model.Email);

                    if (validEmail)
                        throw new ConflictException("email already exists.", "customer.email_already_registered");

                    customer.Email = model.Email;
                }

                if (!string.IsNullOrEmpty(model.PhoneNumber.ToString()))
                    customer.PhoneNumber = model.PhoneNumber;

                if (!string.IsNullOrEmpty(model.City))
                    customer.City = model.City;

                if (!string.IsNullOrEmpty(model.Country))
                    customer.Country = model.Country;

                if (!string.IsNullOrEmpty(model.Address))
                    customer.Address = model.Address;

                if (model.Age >= 14)
                {
                    customer.Age = model.Age;
                }
                else
                {
                    throw new ForbiddenException("user under 14 years old", "OMDbAPI.user_under_14_years_old");
                }

                customer.UpdateDate = DateTime.UtcNow;

                await _movieStoreDbContext.SaveChangesAsync();
            }
            return customer;
        }

        public async Task DeleteCustomer(Guid customerId)
        {
            var customer = GetCustomerById(customerId);

            if (customer.Status == CustomerStatusEnum.ACTIVE)
                throw new ForbiddenException("active user with rented movie", "customer.active_user_with_rented_movie");

            _movieStoreDbContext.Customers.Remove(customer);
            await _movieStoreDbContext.SaveChangesAsync();
        }

    }
}
