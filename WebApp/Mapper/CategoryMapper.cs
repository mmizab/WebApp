using WebApp.DTO;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class CategoryMapper
    {
        public CategoryDto CategoryToDto(Category category)
        {
            CategoryDto dto = new CategoryDto { Id = category.Id, Name = category.Name };
            return dto;
        }
    }
}
