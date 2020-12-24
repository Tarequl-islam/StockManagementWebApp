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
    public partial class CompanySetupUI : System.Web.UI.Page
    {
        CompanyManager companyManager = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            AllCompanyGridView.DataSource = companyManager.AllCompanyName();
            AllCompanyGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            CompanySetUp companySet = new CompanySetUp();
            companySet.Name = companyNameTextBox.Text;
            if (companySet.Name.Length > 1)
            {
                string save = companyManager.Save(companySet);

                outputLabel.Text = save;
                companyNameTextBox.Text = String.Empty;
            }
            else
            {
                outputLabel.Text = "Enter a valid Company Name";
            }

        }
    }
}