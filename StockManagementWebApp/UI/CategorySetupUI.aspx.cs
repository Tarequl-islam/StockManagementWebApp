using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementWebApp.DAL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.UI
{
    public partial class CategorySetupUI : System.Web.UI.Page
    {
        CategoryManger categoryManager = new CategoryManger();
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryListGridView.DataSource = categoryManager.GetAllCategories();
            categoryListGridView.DataBind();
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            
            Category category = new Category();
            category.Name = nameTextBox.Text;
            if (category.Name.Length > 1)
            {
                string messege = categoryManager.Save(category);
                outputLabel.Text = messege;
                if (messege == "Save Successful")
                {
                    nameTextBox.Text = "";
                }

                categoryListGridView.DataSource = categoryManager.GetAllCategories();
                categoryListGridView.DataBind();
            }
            else
            {
                outputLabel.Text = "Enter a valid Category";
            }

        }

        protected void LinkButton_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = sender as LinkButton;
            DataControlFieldCell cell = linkButton.Parent as DataControlFieldCell;
            GridViewRow row = cell.Parent as GridViewRow;
            HiddenField hiddenField = row.FindControl("idHiddenField") as HiddenField;
            int id = Convert.ToInt32(hiddenField.Value);
            Response.Redirect("CategoryUpdateUI.aspx?Id="+id);
        }

    }
}