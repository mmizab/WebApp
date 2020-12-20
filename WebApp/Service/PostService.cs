using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Mapper;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Service
{
    public class PostService
    {
        private WebAppContext Context { get; set; }
        private PostMapper Mapper { get; set; } = new PostMapper();
        public PostService(WebAppContext context)
        {
            Context = context;
        }

        public List<PostDto> GetPosts()
        {
            List<Post> posts = Context.Post.Include(o => o.Category).ToList();
            List<PostDto> dtos = new List<PostDto>();
            foreach (var item in posts)
            {
                dtos.Add(Mapper.PostToDto(item));
            }
            return dtos;
        }

    }
}
