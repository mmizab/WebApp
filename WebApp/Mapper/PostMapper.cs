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
        private CategoryMapper Mapper { get; set; } = new CategoryMapper();
        public PostDto PostToDto(Post post)
        {
            CategoryDto cdto = Mapper.CategoryToDto(post.Category);
            PostDto dto = new PostDto { Title = post.Title, Content = post.Content, CategoryDto = cdto };
            return dto;
        }
    }
}
