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
    public class ViewSalesGateway
    {
        private string connectionString;
        private SqlConnection connection;
        private SqlDataReader reader;

        public ViewSalesGateway()
        {
            connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public List<StockOut> GetAllSatesRecord(SalesDate date)
        {
            string query = "SELECT * FROM SalesRecordView2 WHERE Date >= @FromDate AND Date <= @ToDate";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FromDate", date.FromDate);
            command.Parameters.AddWithValue("@ToDate", date.ToDate);
            connection.Open();
            reader = command.ExecuteReader();
            List<StockOut> stockOutList = new List<StockOut>();
            while (reader.Read())
            {
                StockOut stockOut = new StockOut();
                stockOut.ItemName = reader["ItemName"].ToString();
                stockOut.CompanyName = reader["CompanyName"].ToString();
                stockOut.StockOutQuantity = Convert.ToInt32(reader["Quantity"]);
                stockOutList.Add(stockOut);
            }
            connection.Close();
            return stockOutList;
        }
    }
}