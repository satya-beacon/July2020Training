using BlogPostDemo.Entity;
using System;
using System.Collections.Generic;
using BlogPostDemo.DataAccess;

namespace BlogPostDemo.BusinessLogic
{
    public class BlogDomain : IBlogDomain
    {
        #region private fields
        private IRepository repository;
        #endregion

        public BlogDomain()
        {
            this.repository = new Repository();
        }

        public void AddBlog(Blog blog)
        {
            this.repository.AddBlog(blog);
        }

        public List<Blog> GetAllBlogs()
        {
            throw new NotImplementedException();
        }

        public Blog GetBlogById(int id)
        {
            return this.repository.GetBlogById(id);
        }

        public void RemoveBlog(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
