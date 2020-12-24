using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class ItemsGateway
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public ItemsGateway()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public int Save(Item item)
        {
            string query = "INSERT INTO Items(Name, CategoryId, CompanyId, ReOrder) VALUES(@name, @category, @company, @reorder)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", item.Name);
            command.Parameters.AddWithValue("@category", item.CategoryId); 
            command.Parameters.AddWithValue("@company", item.CompanyId);
            command.Parameters.AddWithValue("@reorder", item.Reorder);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public bool IsNameExist(string name, int categoryId, int companyId)
        {
            string query = "SELECT * FROM Items WHERE Name = @name AND CategoryId = @category AND CompanyId = @company";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@category", categoryId); 
            command.Parameters.AddWithValue("@company", companyId);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;
        }
        public List<Item> GetAllItems()
        {
            string query = "SELECT * FROM Items";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<Item> itemsList = new List<Item>();
            while (reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.Name = reader["Name"].ToString();
                itemsList.Add(item);

            }
            connection.Close();
            return itemsList;
        } 
    }
}