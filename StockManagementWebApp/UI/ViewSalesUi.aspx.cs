using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.UI
{
    public partial class ViewSalesUi : System.Web.UI.Page
    {
        ViewSalesManager viewSalesManager = new ViewSalesManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (fromDateTextbox.Text == "DatePicker" && toDateTextbox.Text == "DatePicker")
            {
                outputLabel.Text = "Please select a date first";
            }
            else
            {
                SalesDate date = new SalesDate();
                date.FromDate = DateTime.ParseExact(fromDateTextbox.Text, "MM/dd/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);
                date.ToDate = DateTime.ParseExact(toDateTextbox.Text, "MM/dd/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture);

               
                if (date.FromDate<=date.ToDate)
                {
                    viewSalesListGridView.DataSource = viewSalesManager.GetAllSatesRecord(date);
                    viewSalesListGridView.DataBind();
                }
                else
                {
                    outputLabel.Text = "Enter a valid Date";
                }

            }
        }
    }
}