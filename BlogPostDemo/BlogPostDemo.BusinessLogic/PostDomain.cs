using BlogPostDemo.EFDataAccess;
using BlogPostDemo.Entity;
using BlostPostDemo.EFDataAccess;
using System.Collections.Generic;

namespace BlogPostDemo.BusinessLogic
{
    public class PostDomain : IPostDomain
    {
        private IRepository repository;

        public PostDomain()
        {
            this.repository = new Repository();
        }
        public int AddPost(Post post)
        {
            return this.repository.AddPost(post);
        }

        public List<Post> GetAllPosts()
        {
            return this.repository.GetAllPosts();
        }

        public Post GetPostById(int id)
        {
            return this.repository.GetPostById(id);
        }
    }
}
