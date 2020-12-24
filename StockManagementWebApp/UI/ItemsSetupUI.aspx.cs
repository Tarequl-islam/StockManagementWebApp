using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.UI
{
    public partial class ItemsSetupUI : System.Web.UI.Page
    {
        ItemManager itemManager = new ItemManager();
        CategoryManger categoryManager = new CategoryManger();
        CompanyManager companyManage = new CompanyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryDropDownList.Items.Add(new ListItem("Select", "0", true));
            categoryDropDownList.DataSource = categoryManager.GetAllCategories();
            categoryDropDownList.DataTextField = "Name";
            categoryDropDownList.DataValueField = "Id";
            categoryDropDownList.DataBind();

            companyDropDownList.Items.Add(new ListItem("Select", "0", true));
            companyDropDownList.DataSource = companyManage.AllCompanyName();
            companyDropDownList.DataTextField = "Name";
            companyDropDownList.DataValueField = "Id";
            companyDropDownList.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if (companyDropDownList.SelectedIndex != 0 && categoryDropDownList.SelectedIndex != 0)
            {
                Item item = new Item();
                item.CategoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
                item.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                item.Name = nameTextBox.Text;
                item.Reorder = Convert.ToInt32(reorderTextBox.Text);
                if (item.Name.Length > 1)
                {
                    string messege = itemManager.Save(item);
                    outputLabel.Text = messege;
                    if (messege == "Save Successfull")
                    {
                        nameTextBox.Text = "";
                        reorderTextBox.Text = "";
                    }
                }
                else
                {
                    outputLabel.Text = "Select Category And Items";
                }
            }
            else
            {
                outputLabel.Text = "Select Company and Category first";
            }
            
        }
    }
}