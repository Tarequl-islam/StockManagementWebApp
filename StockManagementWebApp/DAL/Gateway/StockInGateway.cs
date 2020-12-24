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
    public class StockInGateway
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public StockInGateway()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        public int ItemUpdate(StockOut stockOutt)
        {
            string query = "UPDATE Items SET Available = Available + @Quantity WHERE Id = @ItemId AND CompanyId = @CompanyId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CompanyId", stockOutt.CompanyId);
            command.Parameters.AddWithValue("@ItemId", stockOutt.ItemId);
            command.Parameters.AddWithValue("@Quantity", stockOutt.StockOutQuantity);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();
            return rowAffect;
        }
    }
}