using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Mapper;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using WebApp.Controllers;
using System;
using System.Security.Claims;

namespace WebApp.Service
{
    public class PostService {

        private PostMapper PostMapper { get; set; } = new PostMapper();
        private WebAppContext Context {get;set;}

        public PostService(WebAppContext context){
            Context = context;
        }

        public List<PostDto> GetPosts(string category)
        {
            List<Post> posts = new List<Post>();
            if (category != null)
            {
                posts = Context.Post.Include(o => o.Category).Where(o => o.Category.Name == category).ToList();
            }
            else
            {
                posts = Context.Post.Include(o => o.Category).ToList();
            }
            List<PostDto> dtos = new List<PostDto>();
            foreach (var item in posts)
            {
                dtos.Add(PostMapper.PostToDto(item));
            }
            return dtos;
        }

        public void PostSave(AdminPostDto postdto, Store store, Category category) {

            Post post = new Post { Store = store, Title = postdto.Title, Content = postdto.Content, Category = category };
            post.CreateDate = DateTime.Now;

            Context.Post.Add(post);
            Context.SaveChanges();

            if (post.Id == 0)
            {
                throw new Exception("Error saving post");
            }
        }

    }
}
