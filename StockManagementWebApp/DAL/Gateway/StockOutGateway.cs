using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class StockOutGateway
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public StockOutGateway()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public List<Item> GetAllSelectedItems(int companyId)
        {
            string query = "SELECT * FROM Items WHERE CompanyId= @companyId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@companyId", companyId);
            connection.Open();
            reader = command.ExecuteReader();
            List<Item> itemsList = new List<Item>();
            while (reader.Read())
            {
                Item item = new Item();
                item.Id = Convert.ToInt32(reader["Id"]);
                item.Name = reader["Name"].ToString();
                item.Reorder = Convert.ToInt32(reader["ReOrder"]);
                item.Available = Convert.ToInt32(reader["Available"]);
                itemsList.Add(item);

            }
            connection.Close();
            return itemsList;
        }
        public bool IsNameExist(int companyId, int itemId)
        {
            string query = "SELECT * FROM StockOut WHERE CompanyId = @CompanyId AND ItemId = @itemId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyId", companyId);
            command.Parameters.AddWithValue("@itemId", itemId);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();
            return isExist;
        }
        public int Save(StockOut stockOut)
        {
            string query = "INSERT INTO StockOut(CompanyId, ItemId, Quantity) VALUES(@CompanyId, @ItemId, @Quantity)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyId", stockOut.CompanyId);
            command.Parameters.AddWithValue("@ItemId", stockOut.ItemId);
            command.Parameters.AddWithValue("@Quantity", stockOut.StockOutQuantity);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public List<StockOut> GetAllStockOuts()
        {
            string query = "SELECT * FROM StockOutView2";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<StockOut> stockOutList= new List<StockOut>();
            while (reader.Read())
            {
                StockOut stockOut = new StockOut();
                stockOut.ItemId = Convert.ToInt32(reader["Id"]);
                stockOut.ItemName = reader["Name"].ToString();
                stockOut.CompanyName = reader["CompanyName"].ToString();
                stockOut.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                stockOut.StockOutQuantity = Convert.ToInt32(reader["Quantity"]);
                stockOutList.Add(stockOut);
            }
            connection.Close();
            return stockOutList;
        }

        public int Update(StockOut stockOuts)
        {
            string query = "UPDATE StockOut SET Quantity = Quantity + @Quantity WHERE CompanyId = @CompanyId AND ItemId = @ItemId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyId", stockOuts.CompanyId);
            command.Parameters.AddWithValue("@ItemId", stockOuts.ItemId);
            command.Parameters.AddWithValue("@Quantity", stockOuts.StockOutQuantity);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public int ItemUpdate(StockOut stockOutt)
        {
            string query = "UPDATE Items SET Available = Available - @Quantity WHERE Id = @ItemId AND CompanyId = @CompanyId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyId", stockOutt.CompanyId);
            command.Parameters.AddWithValue("@ItemId", stockOutt.ItemId);
            command.Parameters.AddWithValue("@Quantity", stockOutt.StockOutQuantity);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

        public int StockOutDelete(StockOut stockOut3)
        {
            string query =
                "DELETE FROM StockOut WHERE CompanyId = @CompanyId AND ItemId = @itemId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyId", stockOut3.CompanyId);
            command.Parameters.AddWithValue("@itemId", stockOut3.ItemId);
            //command.Parameters.AddWithValue("@Quantity", stockOutt.StockOutQuantity);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
        public int SatesRecord(StockOut stockOutItem)
        {
            string query = "INSERT INTO SalesRecord(ItemId, CompanyId, Quantity, Date) " +
                           "VALUES(@ItemId, @CompanyId, @Quantity, @Date)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ItemId", stockOutItem.ItemId);
            command.Parameters.AddWithValue("@CompanyId", stockOutItem.CompanyId);
            command.Parameters.AddWithValue("@Quantity", stockOutItem.StockOutQuantity);
            command.Parameters.AddWithValue("@Date", stockOutItem.Date);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }

    }
}