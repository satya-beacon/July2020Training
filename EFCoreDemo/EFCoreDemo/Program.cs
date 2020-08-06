using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;
namespace EFCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogDbContext context = new BlogDbContext();
            
            var blogs = context.Blogs.ToList();

            var firstBlog = context.Blogs.FirstOrDefault();

            var blog1 = context.Blogs.Where(b => b.Id == 1).FirstOrDefault();

            context.Blogs.Add(new Blog() { Title = "EF", Author = "John", DateCreated = DateTime.Now });
            context.SaveChanges();



            var posts = context.Posts.ToList();

            var post = context.Posts.Where(p => p.Id == 3).FirstOrDefault();

            var postBlog = context.Blogs.FirstOrDefault(b => b.Id == post.BlogId);


            var blogtoAdd = new Blog() { Title = "EF TRaining", Author = "James", DateCreated = DateTime.Now };
            context.Blogs.Add(blogtoAdd);
            context.SaveChanges();


            var postToAdd = new Post() { Title = "EF Code First Demo", Author = "Satya", Dsc = "Test DSc", DateCreated = DateTime.Now, BlogId = blogtoAdd.Id };
            context.Posts.Add(postToAdd);

            context.SaveChanges();



            var efBlogs = context.Blogs.Where(b => b.Id == 4).FirstOrDefault();

            
        }
    }
}
