using System;
using BlogPostDemo.Entity;
using BlogPostDemo.BusinessLogic;

namespace BlogPostDemo.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IBlogDomain blogDomain = new BlogDomain();
            blogDomain.AddBlog(new Blog() { Title = "SQL Server", Author = "Satya", DateCreated = DateTime.Now });

            var blog = blogDomain.GetBlogById(1);
            Console.WriteLine($"{blog.Id} {blog.Title} {blog.Author} {blog.DateCreated}");
        }
    }
}
