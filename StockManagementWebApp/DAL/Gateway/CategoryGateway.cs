using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class CategoryGateway
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public CategoryGateway()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public int Save(Category category)
        {
            string query = "INSERT INTO Category(Name) VALUES(@name)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", category.Name);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsNameExist(string name)
        {
            string query = "SELECT * FROM Category WHERE Name = @name";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            connection.Open();
            reader = command.ExecuteReader();
            bool IsExist = reader.HasRows;
            connection.Close();
            return IsExist;
        }

        public List<Category> GetAllCategories()
        {
            string query = "SELECT * FROM Category";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Category> categoryList = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(reader["Id"]);
                category.Name = reader["Name"].ToString();
                categoryList.Add(category);

            }
            connection.Close();
            return categoryList;
        } 
        public Category GetCategoryById(int id)
        {
            string query = "SELECT * FROM Category WHERE Id=@Id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            Category category = null;
            if (reader.HasRows)
            {
                category = new Category();
                category.Id = Convert.ToInt32(reader["Id"]);
                category.Name = reader["Name"].ToString();
            }
            
            connection.Close();
            return category;
        }

        public int Update(Category category)
        {
            string query = "UPDATE Category SET Name = @name WHERE Id= @id";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", category.Name);
            command.Parameters.AddWithValue("@id", category.Id);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

    }
}