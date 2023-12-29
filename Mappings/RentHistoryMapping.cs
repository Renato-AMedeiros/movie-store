using renato_movie_store.Context.Model;
using renato_movie_store.Mappings.ModelsMappings;

namespace renato_movie_store.Mappings
{
    public class RentHistoryMapping
    {
        public static RentHistoryMappingModel RentHistoryMap(RentHistory rentHistoryContext)
        {
            var rentHistoryResponse = new RentHistoryMappingModel
            {
                RentId = rentHistoryContext.RentId,
                Name = rentHistoryContext.Name,
                ImdbId = rentHistoryContext.ImdbId,
                Title = rentHistoryContext.Title,
                Type = rentHistoryContext.Type,
                CustomerId = rentHistoryContext.CustomerId,
                CPF = rentHistoryContext.CPF,
                CreateDate = rentHistoryContext.CreateDate,
                UpdateDate = rentHistoryContext.UpdateDate,
                ExpireDate = rentHistoryContext.ExpireDate,
            };

            return rentHistoryResponse;
        }
    }
}
