using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApp.Models
{
    public class BlogRepository
    {
        private List<Blog> blogs;

       public BlogRepository()
        {
            this.blogs = new List<Blog>();
        }


       public List<Blog> GetBlogs()
        {
            this.blogs.AddRange(new List<Blog>(){
                new Blog() { Id = 1, Title = "ASP.NET Core", Author = "Satya", DateCreated = DateTime.Now }, 
                new Blog() { Id = 2, Title = "C#", Author = "John", DateCreated = DateTime.Now}});

            return this.blogs;
        }
    }
}
