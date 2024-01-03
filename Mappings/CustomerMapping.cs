using renato_movie_store.Context.Model;
using renato_movie_store.Mappings.ModelsMappings;

namespace renato_movie_store.Mappings
{
    public class CustomerMapping
    {
        public static CustomerMappingModel CustomerMap(Customer customerContext)
        {
            var customerResponse = new CustomerMappingModel
            {
                CustomerId = customerContext.CustomerId,
                CustomerName = customerContext.CustomerName,
                Genero = customerContext.Genero,
                Email = customerContext.Email,
                Age = customerContext.Age,
                CPF = customerContext.CPF,
                Address = customerContext.Address,
                City = customerContext.City,
                Country = customerContext.Country,
                PhoneNumber = customerContext.PhoneNumber,
                CreateDate = customerContext.CreateDate,
                UpdateDate = customerContext.UpdateDate,
            };

            return customerResponse;
        }
    }
}
