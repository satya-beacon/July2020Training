using System.Collections.Generic;
using BlogPostDemo.Entity;

namespace BlogPostDemo.DataAccess
{
    public interface IRepository
    {
        public void AddBlog(Blog blog);
        public void UpdateBlog(Blog blog);
        public void RemoveBlog(int id);
        Blog GetBlogById(int id);
        List<Blog> GetAllBlogs();


        public int AddPost(Post post);
        public void UpdatePost(Post post);
        public void Remove(int id);
        Post GetPostById(int id);
        List<Post> GetAllPosts();


        void TransferAccountBalance(int fromAccount, int toAccount, decimal amount);

    }
}
