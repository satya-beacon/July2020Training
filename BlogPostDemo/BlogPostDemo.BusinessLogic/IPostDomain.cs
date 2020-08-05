using BlogPostDemo.Entity;
using System.Collections.Generic;

namespace BlogPostDemo.BusinessLogic
{
    public interface IPostDomain
    {
        int AddPost(Post post);
        Post GetPostById(int id);
        List<Post> GetAllPosts();
    }
}
