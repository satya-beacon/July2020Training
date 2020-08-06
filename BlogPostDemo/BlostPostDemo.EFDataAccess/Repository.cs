using BlogPostDemo.EFDataAccess;
using BlogPostDemo.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlostPostDemo.EFDataAccess
{
    public class Repository : IRepository
    {
        private BlogPostDbContext context;

        public Repository()
        {
            this.context = new BlogPostDbContext();
        }

        public void AddBlog(Blog blog)
        {
            this.context.Blogs.Add(blog);
            this.context.SaveChanges();
        }

        public int AddPost(Post post)
        {
            this.context.Posts.Add(post);
            this.context.SaveChanges();
            return post.Id;
        }

        public List<Blog> GetAllBlogs()
        {
            return this.context.Blogs.ToList();
        }

        public List<Post> GetAllPosts()
        {
            return this.context.Posts.ToList();
        }

        public Blog GetBlogById(int id)
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveBlog(int id)
        {
            throw new NotImplementedException();
        }

        public void TransferAccountBalance(int fromAccount, int toAccount, decimal amount)
        {
            throw new NotImplementedException();
        }

        public void UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new NotImplementedException();
        }
    }
}
