using BlogPostDemo.Entity;
using System.Collections.Generic;

namespace BlogPostDemo.BusinessLogic
{
    public interface IBlogDomain
    {
        public void AddBlog(Blog blog);
        public void UpdateBlog(Blog blog);
        public void RemoveBlog(int id);
        Blog GetBlogById(int id);
        List<Blog> GetAllBlogs();
    }
}
