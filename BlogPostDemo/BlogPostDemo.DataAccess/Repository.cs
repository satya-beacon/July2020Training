
using BlogPostDemo.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace BlogPostDemo.DataAccess
{
    /// <summary>
    /// This is the data access logic using ADO.NET
    /// </summary>
    public class Repository : IRepository
    {
        #region private fields

        private SqlConnection connection;
        private readonly string CONNECTIONSTRING = "Data Source = sbx-01-sql-cti-ctidm.corp.fmglobal.com,1010; Initial Catalog=PracticeDb; Integrated Security = true";

        #endregion

        #region constructor
        public Repository()
        {

        }
        #endregion

        #region private methods
        private void EnsureOpenConnection()
        {
                connection = new SqlConnection();
                connection.ConnectionString = this.CONNECTIONSTRING;
                connection.Open();
        }

        private void EnsureCloseConnection()
        {
            connection.Close();
        }
        #endregion

        #region public methods
        public void AddBlog(Blog blog)
        {
            try
            {
                EnsureOpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = $"INSERT INTO Blog Values('{blog.Title}', '{blog.Author}', '{blog.DateCreated}')";

                command.ExecuteNonQuery();
                command.Dispose();

                EnsureCloseConnection();

            }
            catch(Exception ex)
            {
                //log exceptions
            }
        }

        public int AddPost(Post post)
        {
            try
            {
                EnsureOpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[spc_AddPost]";

                SqlParameter postTitle = new SqlParameter("@Title", SqlDbType.NVarChar, 100);
                postTitle.Value = post.Title;
                command.Parameters.Add(postTitle);
                
                command.Parameters.AddWithValue("@Author", post.Author);
                command.Parameters.AddWithValue("@Dsc", post.Dsc);
                command.Parameters.AddWithValue("@BlogId", post.BlogId);

                SqlParameter insertedPostId = new SqlParameter("@PostId", SqlDbType.Int);
                insertedPostId.Direction = ParameterDirection.Output;
                command.Parameters.Add(insertedPostId);

                command.ExecuteNonQuery();
                post.Id = Convert.ToInt32( insertedPostId.Value);

                command.Dispose();
                EnsureCloseConnection();

            }
            catch(Exception ex)
            {
                //log the exceptions 
            }

            return post.Id;
        }

        public List<Blog> GetAllBlogs()
        {
            throw new System.NotImplementedException();
        }

        public List<Post> GetAllPosts()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = this.CONNECTIONSTRING;

           

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM POST", sqlConnection);
            

            DataSet postDataSet = new DataSet();
            adapter.Fill(postDataSet, "post");

            DataTable table = postDataSet.Tables["post"];
            List<Post> allPosts = new List<Post>();
            foreach(DataRow row in table.Rows)
            {
                allPosts.Add(new Post() 
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Title = row["Title"].ToString(),
                    Author = row["Author"].ToString(),
                    Dsc = row["Dsc"].ToString(),
                    DateCreated = Convert.ToDateTime(row["DateCreated"]),
                    BlogId = Convert.ToInt32(row["BlogId"])

                });
            }

            return allPosts;
        }

        public Blog GetBlogById(int id)
        {
            Blog blogToReturn = null;
            try
            {
                EnsureOpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = $"SELECT * FROM BLOG WHERE ID = {id}";

                SqlDataReader reader = command.ExecuteReader();
                if(reader != null)
                {
                    reader.Read();
                    blogToReturn = new Blog();
                    blogToReturn.Id = Convert.ToInt32(reader["Id"]);
                    blogToReturn.Title = Convert.ToString(reader["Title"]);
                    blogToReturn.Author = Convert.ToString(reader["Author"]);
                    blogToReturn.DateCreated = Convert.ToDateTime(reader["DateCreated"]);
                    reader.Close();
                    command.Dispose();
                }

                EnsureCloseConnection();
            }
            catch(Exception ex)
            {
                //log the exception
            }
            return blogToReturn;
        }

        public Post GetPostById(int id)
        {
            Post returnPost = null;

            try
            {
                EnsureOpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[dbo].[spr_getPostById]";

                command.Parameters.AddWithValue("@id", id);


                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    returnPost = new Post();
                    returnPost.Id = Convert.ToInt32( reader["Id"]);
                    returnPost.Title = Convert.ToString(reader["Title"]);
                    returnPost.Author = Convert.ToString(reader["Author"]);
                    returnPost.Dsc = Convert.ToString(reader["Dsc"]);
                    returnPost.DateCreated = Convert.ToDateTime(reader["DateCreated"]);

                    returnPost.Blog = new Blog();
                    returnPost.Blog.Id = Convert.ToInt32(reader["BlogId"]);
                    returnPost.Blog.Title = Convert.ToString(reader["BlogTitle"]);
                    returnPost.Blog.Author = Convert.ToString(reader["BlogAuthor"]);
                    returnPost.Blog.DateCreated = Convert.ToDateTime(reader["BlogCreatedDate"]);
                }
                reader.Dispose();
                EnsureCloseConnection();
            }
            catch(Exception ex)
            {

            }

            return returnPost;
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveBlog(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateBlog(Blog blog)
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePost(Post post)
        {
            throw new System.NotImplementedException();
        }

        public void TransferAccountBalance(int fromAccount, int toAccount, decimal amount)
        {
            try
            {
                EnsureOpenConnection();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spu_transferBalance";

                command.Parameters.AddWithValue("@FromAccount", fromAccount);
                command.Parameters.AddWithValue("@ToAccount", toAccount);
                command.Parameters.AddWithValue("@Amount", amount);

                command.ExecuteNonQuery();

                EnsureCloseConnection();

            }
            catch(Exception ex)
            {

            }
        }
        #endregion
    }
}
