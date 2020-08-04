using System;
using System.Data;
using System.Data.SqlClient;

namespace FirstDataApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initalize the connection
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source = sbx-01-sql-cti-ctidm.corp.fmglobal.com,1010; Initial Catalog = PracticeDb; Integrated Security = true";
            connection.Open();
            Console.WriteLine("Connection is initialized");
            
            //Create the command
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM Employee";

            //Execute command
            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                //process/retreive the data
                for(var i = 0; i< reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i]} ");
                }

                Console.WriteLine(Environment.NewLine);
            }

            command.Dispose();
            connection.Close();
            Console.WriteLine("Connection is closed");

        }
    }
}
