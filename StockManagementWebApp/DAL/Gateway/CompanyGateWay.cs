using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.DAL.Gateway
{
    public class CompanyGateWay
    {
        
        private SqlConnection connection;
        public SqlCommand command;
        public SqlDataReader reader;

        public CompanyGateWay()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["StockManagementDBconString"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }
        public int Save(CompanySetUp company)
        {
             string query = "INSERT INTO Company(Name) VALUES(@name)";
             command = new SqlCommand(query, connection);
             command.Parameters.AddWithValue("@name", company.Name);
             connection.Open();
             int rowaffect = command.ExecuteNonQuery();
             connection.Close();
             return rowaffect;
        }
        public bool IsExistName(string name)
        {
            string query = "SELECT  * FROM Company WHERE Name=@companyname";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@companyname", name);
            connection.Open();
            reader = command.ExecuteReader();
            bool isExists = reader.HasRows;
            connection.Close();
            return isExists;
        }
        public List<CompanySetUp> CompanylList()
        {
            string query = "SELECT * FROM Company";
            command = new SqlCommand(query, connection);
            connection.Open();
            reader = command.ExecuteReader();
            List<CompanySetUp> companySetList= new List<CompanySetUp>();
            while (reader.Read())
            {
                CompanySetUp company = new CompanySetUp();
                company.Id = Convert.ToInt32(reader["Id"]);
                company.Name = reader["Name"].ToString();
                companySetList.Add(company);
            }
            connection.Close();
            return companySetList;
        }
    }
}