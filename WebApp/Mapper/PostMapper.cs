using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.DTO;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class PostMapper
    {
        private CategoryMapper Mapper = new CategoryMapper();
        private StoreMapper StoreMapper = new StoreMapper();
        public PostDto PostToDto(Post post)
        {
            CategoryDto cdto = Mapper.CategoryToDto(post.Category);
            StoreDto sdto = StoreMapper.StoreToDto(post.Store);
            PostDto dto = new PostDto { Title = post.Title, Content = post.Content, CategoryDto = cdto, StoreDto = sdto, Id = post.Id };
            return dto;
        }
    }
}
