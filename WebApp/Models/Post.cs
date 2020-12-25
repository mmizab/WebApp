using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        public Store Store { get; set; }
        public Category Category { get; set; }
    }
}
