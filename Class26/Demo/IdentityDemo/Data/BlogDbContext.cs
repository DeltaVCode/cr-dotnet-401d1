using IdentityDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDemo.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = 1,
                    Title = "Hello World",
                    Contents = "Hello, World was created by Brian Kernighan. This term also refers to a simple introductory program for beginners. "
                },
                new Post
                {
                    Id = 2,
                    Title = "Intro to C#",
                    Contents = "C# is a programming language created by Microsoft in 2000. It is widely used for many different applications. we love C#"
                },
                new Post
                {
                    Id = 3,
                    Title = "A simple riddle",
                    Contents = "How much wood could a woodchuck chuck, if a woodchuck could chuck wood?"
                }
                );
        }

        public DbSet<Post> Posts { get; set; }
    }
}
