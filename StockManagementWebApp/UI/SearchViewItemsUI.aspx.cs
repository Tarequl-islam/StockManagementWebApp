using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StockManagementProjectApp.BLL;
using StockManagementWebApp.BLL;
using StockManagementWebApp.DAL;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.UI
{
    public partial class SearchViewItemsUI : System.Web.UI.Page
    {
        StockOutManager stockOutManager = new StockOutManager();
        SearchViewItemsManager searchAndViewManager = new SearchViewItemsManager();
        CompanyManager companyManager = new CompanyManager();
        CategoryManger catagoryManager = new CategoryManger();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.Items.Add(new ListItem("Select", "0", true));
                companyDropDownList.DataSource = companyManager.AllCompanyName();
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
                categoryDropDownList.Items.Add(new ListItem("Select", "0", true));
                categoryDropDownList.DataSource = catagoryManager.GetAllCategories();
                categoryDropDownList.DataTextField = "Name";
                categoryDropDownList.DataValueField = "Id";
                categoryDropDownList.DataBind();
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {

            outputLabel.Text = String.Empty;
            viewItemListGridView.DataSource = null;
            viewItemListGridView.DataBind();

            if (companyDropDownList.SelectedIndex != 0 && categoryDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                int categoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
                if (searchAndViewManager.GetItemsByCompanyIdAndCategoryId(companyId, categoryId) != null)
                {
                    viewItemListGridView.DataSource = searchAndViewManager.GetItemsByCompanyIdAndCategoryId(companyId, categoryId);
                    viewItemListGridView.DataBind();

                    companyDropDownList.SelectedIndex = 0;
                    categoryDropDownList.SelectedIndex = 0;
                }
                else
                {
                    outputLabel.Text = "The Item does not exist";
                }
            }
            else if (companyDropDownList.SelectedIndex != 0)
            {
                int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                viewItemListGridView.DataSource = searchAndViewManager.GetItemsByCompanyId(companyId);
                viewItemListGridView.DataBind();

                companyDropDownList.SelectedIndex = 0;
                categoryDropDownList.SelectedIndex = 0;
            }
            else if (categoryDropDownList.SelectedIndex != 0)
            {
                int categoryId = Convert.ToInt32(categoryDropDownList.SelectedValue);
                viewItemListGridView.DataSource = searchAndViewManager.GetItemsByCategoryId(categoryId);
                viewItemListGridView.DataBind();

                companyDropDownList.SelectedIndex = 0;
                categoryDropDownList.SelectedIndex = 0;
            }
            else if(companyDropDownList.SelectedIndex == 0 && categoryDropDownList.SelectedIndex == 0)
            {
                outputLabel.Text = "Please Select at least One Section";
            }
            else 
            {
                outputLabel.Text = "No Item found";
            }
        }


    }
}