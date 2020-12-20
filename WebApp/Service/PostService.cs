using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Mapper;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using WebApp.Controllers;
using System;

namespace WebApp.Service
{
    public class PostService:BaseService
    {
        private PostMapper PostMapper { get; set; }
        public PostService(WebAppContext context): base(context)
        {
        }

        public List<PostDto> GetPosts()
        {
            List<Post> posts = Context.Post.Include(o => o.Category).ToList();
            List<PostDto> dtos = new List<PostDto>();
            foreach (var item in posts)
            {
                dtos.Add(PostMapper.PostToDto(item));
            }
            return dtos;
        }

        public void PostSave(PostDto postdto) {

            Store store = StoreService.GetStore(postdto.StoreId);
            Category category = CategoryService.GetCategory(postdto.CategoryId);

            Post post = new Post { Store = store, Title = postdto.Title, Content = postdto.Content, Category = category };
            post.CreateDate = DateTime.Now;

            Save(post);

            if (post.Id == 0)
            {
                throw new Exception("Error saving post");
            }
        }

    }
}
