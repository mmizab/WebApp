using WebApp.DTO;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class StoreMapper
    {
        public StoreDto StoreToDto(Store store)
        {
            StoreDto dto = new StoreDto { Id = store.Id, Name = store.Name };
            return dto;
        }
    }
}
