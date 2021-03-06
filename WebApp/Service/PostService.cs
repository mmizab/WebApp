﻿using System.Collections.Generic;
using System.Linq;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Mapper;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;


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
                posts = Context.Post.Include(o => o.Category).Include(o => o.Store).Where(o => o.Category.Name == category).ToList();
            }
            else
            {
                posts = Context.Post.Include(o => o.Category).Include(o => o.Store).ToList();
            }
            List<PostDto> dtos = new List<PostDto>();
            foreach (var item in posts)
            {
                PostDto dto = PostMapper.PostToDto(item);



                dtos.Add(dto);
            }
            return dtos;
        }

        public void PostSave(AdminPostDto postdto, Store store, Category category) {

            Post post = new Post { Store = store, Title = postdto.Title, Content = postdto.Content, Category = category, Points = postdto.Points};
            post.CreateDate = DateTime.Now;

            Context.Post.Add(post);
            Context.SaveChanges();

            if (post.Id == 0)
            {
                throw new Exception("Error saving post");
            }
        }

        internal PostDto GetPost(int id)
        {
            Post post = Context.Post.Include(o => o.Category).Include(o => o.Store).FirstOrDefault(o => o.Id == id);
            if (post == null)
            {
                throw new Exception("Error finding post");
            }

            PostDto dto = PostMapper.PostToDto(post);

            byte[] qrcode = CodeQrService.GenerateQr(Config.AppDomain + "/oferta/" + post.Id);
            dto.QrCode = qrcode;


            return dto;
        }
    }
}
