
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
            if(connection == null)
            {
                connection = new SqlConnection();
                connection.ConnectionString = this.CONNECTIONSTRING;
                connection.Open();
            }
        }

        private void EnsureCloseConnection()
        {
            if(connection != null)
            {
                connection.Close();
            }
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

        public void AddPost(Post post)
        {
            throw new System.NotImplementedException();
        }

        public List<Blog> GetAllBlogs()
        {
            throw new System.NotImplementedException();
        }

        public List<Post> GetAllPosts()
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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
        #endregion
    }
}
