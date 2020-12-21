using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Data
{
    public class WebAppContext : DbContext
    {
        public WebAppContext(DbContextOptions<WebAppContext> options): base(options)
        {

        }

        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Job> Job { get; set; }
    }
}
