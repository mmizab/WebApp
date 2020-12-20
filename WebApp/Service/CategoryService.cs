using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Controllers;
using WebApp.Data;
using WebApp.DTO;
using WebApp.Mapper;
using WebApp.Models;

namespace WebApp.Service
{
    public class CategoryService
    {
        private WebAppContext Context;
        private CategoryMapper CategoryMapper { get; set; } = new CategoryMapper();
        public CategoryService(WebAppContext context)
        {
            Context = context;
        }

        public List<CategoryDto> GetCategoriesDto()
        {
            List<Category> categories = Context.Category.ToList();
            List<CategoryDto> dtos = new List<CategoryDto>();
            foreach (var item in categories)
            {
                dtos.Add(CategoryMapper.CategoryToDto(item));
            }
            return dtos;
        }
        public Category GetCategory(int categoryId)
        {

            Category category = Context.Category.FirstOrDefault(o => o.Id == categoryId);

            if (category == null)
            {
                throw new Exception("Error getting category");
            }

            return category;
        }


    }

}
