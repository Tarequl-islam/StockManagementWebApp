using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementProjectApp.DAL.Models;
using StockManagementWebApp.DAL.Model;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class SearchViewItemGateway
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;
        SqlCommand command;

        public SearchViewItemGateway()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        
        public List<ItemsView> GetItemsByCompanyIdAndCategoryId(int companyId, int categoryId)
        {
            string query = "SELECT * FROM ItemsView2 WHERE CompanyId = @companyId AND CategoryId = @categoryId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@companyId", companyId);
            command.Parameters.AddWithValue("@categoryId", categoryId);
            connection.Open();
            reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                connection.Close();
                return null;
            }
            List<ItemsView> itemList = new List<ItemsView>();
            while (reader.Read())                                           //Reading database row by row
            {
                ItemsView item = new ItemsView();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();
                item.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                item.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                item.CompanyName = (reader["CompanyName"]).ToString();
                item.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                item.CategoryName = (reader["CategoryName"]).ToString();

                itemList.Add(item);
            }
            connection.Close();

            return itemList;
        }

        public List<ItemsView> GetItemsByCategoryId(int categoryId)
        {
            string query = "SELECT * FROM ItemsView2 WHERE CategoryId = @categoryId";
            command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@categoryId", categoryId);
            
            connection.Open();
            reader = command.ExecuteReader();

            List<ItemsView> itemList = new List<ItemsView>();
            while (reader.Read())                                           //Reading database row by row
            {
                ItemsView item = new ItemsView();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();
                item.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                item.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                item.CompanyName = (reader["CompanyName"]).ToString();
                item.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                item.CategoryName = (reader["CategoryName"]).ToString();

                itemList.Add(item);
            }
            connection.Close();

            return itemList;
        }

        public List<ItemsView> GetItemsByCompanyId(int companyId)
        {
            string query = "SELECT * FROM ItemsView2 WHERE CompanyId = @companyId";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@companyId", companyId);
            connection.Open();
            reader = command.ExecuteReader();

            List<ItemsView> itemList = new List<ItemsView>();
            while (reader.Read())                                           //Reading database row by row
            {
                ItemsView item = new ItemsView();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();
                item.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                item.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                item.CompanyName = (reader["CompanyName"]).ToString();
                item.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                item.CategoryName = (reader["CategoryName"]).ToString();

                itemList.Add(item);
            }
            connection.Close();

            return itemList;
        }

    }
}