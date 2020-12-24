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
    public partial class CategoryUpdateUI : System.Web.UI.Page
    {
        CategoryManger categoryManger = new CategoryManger();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["Id"]);

                Category category = categoryManger.GetCategoryById(id);
                if (category != null)
                {
                    idHiddenField.Value = category.Id.ToString();
                    nameTextBox.Text = category.Name;
                }
            }
            
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.Name = nameTextBox.Text;
            category.Id = Convert.ToInt32(idHiddenField.Value);
            categoryManger.Update(category);
            Response.Redirect("CategorySetupUI.aspx");
        }



    }
}