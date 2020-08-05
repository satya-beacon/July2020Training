using System;
using BlogPostDemo.Entity;
using BlogPostDemo.BusinessLogic;

namespace BlogPostDemo.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //    IBlogDomain blogDomain = new BlogDomain();
            //    blogDomain.AddBlog(new Blog() { Title = "SQL Server", Author = "Satya", DateCreated = DateTime.Now });

            //    var blog = blogDomain.GetBlogById(4);
            //    Console.WriteLine($"{blog.Id} {blog.Title} {blog.Author} {blog.DateCreated}");

            //IPostDomain postDomain = new PostDomain();
            //int postId = postDomain.AddPost(new Post() { Title = "Learning Proc demo" , Author = "JOhn", Dsc = "Test dsc", BlogId = 4 });

            //Post post = postDomain.GetPostById(postId);


            //ICustomerDomain customerDomain = new CustomerDomain();
            //customerDomain.TransferAccountBalance(1, 9, 100);

            IPostDomain postDomain = new PostDomain();
            var posts = postDomain.GetAllPosts();


        }
    }
}
