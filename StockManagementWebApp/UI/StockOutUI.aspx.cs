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
    public partial class StockOutUI : System.Web.UI.Page
    {
        StockOutManager stockOutManager = new StockOutManager();
        CompanyManager companyManager = new CompanyManager();
        ItemManager itemManager = new ItemManager();
        //private string tempstring;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                companyDropDownList.Items.Add(new ListItem("Select", "0", true));
                companyDropDownList.DataSource = companyManager.AllCompanyName();
                companyDropDownList.DataTextField = "Name";
                companyDropDownList.DataValueField = "Id";
                companyDropDownList.DataBind();
            }
            stockOutListGridView.DataSource = stockOutManager.GetAllStockOuts();
            stockOutListGridView.DataBind();
        }

        protected void companyDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            companyDropDownList.Items.Remove(companyDropDownList.Items.FindByText("Select"));
            companyDropDownList.DataBind();
            int companyId = Convert.ToInt32(companyDropDownList.SelectedValue);
            itemDropDownList.Items.Add(new ListItem("Select", "0", true));
            itemDropDownList.DataSource = stockOutManager.GetAllSelectedItems(companyId);
            itemDropDownList.DataTextField = "Name";
            itemDropDownList.DataValueField = "Id";
            itemDropDownList.DataBind();
        }

        protected void itemDropDownList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            itemDropDownList.Items.Remove(itemDropDownList.Items.FindByText("Select"));
            itemDropDownList.DataBind();
            List<Item> itemList = stockOutManager.GetAllSelectedItems(Convert.ToInt32(companyDropDownList.SelectedValue));
            foreach (Item item in itemList)
            {
                if (item.Id== Convert.ToInt32(itemDropDownList.SelectedValue))
                {
                    reorderLevelTextBox.Text = item.Reorder.ToString();
                    availableQuantityTextBox.Text = item.Available.ToString();
                    break;
                }
            }
            
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            if ( stockoutQuantityTextBox.Text.Trim() == string.Empty && availableQuantityTextBox.Text.Trim() == string.Empty)
            {
                outputLabel.Text = "Enter a quantity in the Stock Out Quantity or select a Item";
            }
            else
            {
                StockOut stockOut = new StockOut();
                stockOut.CompanyId = Convert.ToInt32(companyDropDownList.SelectedValue);
                stockOut.ItemId = Convert.ToInt32(itemDropDownList.SelectedValue);
                //stockOut.ReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                stockOut.AvailableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                stockOut.StockOutQuantity = Convert.ToInt32(stockoutQuantityTextBox.Text);
                if (stockOut.StockOutQuantity > 0 && stockOut.StockOutQuantity <= stockOut.AvailableQuantity)
                {
                    string messege = stockOutManager.Save(stockOut);
                    outputLabel.Text = messege;
                    if (messege == "Save Successful")
                    {
                        reorderLevelTextBox.Text = "";
                        availableQuantityTextBox.Text = "";
                        stockoutQuantityTextBox.Text = "";
                    }
                }
                else
                {
                    outputLabel.Text = "Enter a valid Quantity";
                }
                stockOutListGridView.DataSource = stockOutManager.GetAllStockOuts();
                stockOutListGridView.DataBind();
            }
        }

        protected void sellButton_Click(object sender, EventArgs e)
        {
            List<StockOut> stockOutList = stockOutManager.GetAllStockOuts();
            if (stockOutList.Count == 0)
            {
                outputLabel.Text = "Add Items in the list First";
            }
            else
            {
                foreach (StockOut stockOut in stockOutList)
                {
                    stockOut.Date = System.DateTime.Today;
                    stockOutManager.ItemUpdate(stockOut);
                    stockOutManager.StockOutDelete(stockOut);
                    stockOutManager.SatesRecord(stockOut);
                }
                stockOutListGridView.DataSource = stockOutManager.GetAllStockOuts();
                stockOutListGridView.DataBind();
                outputLabel.Text = "Stock Out Successful";
            }
        }

        protected void damageButton_Click(object sender, EventArgs e)
        {

            List<StockOut> stockOutList = stockOutManager.GetAllStockOuts();
            if (stockOutList.Count == 0)
            {
                outputLabel.Text = "Add Items in the list First";
            }
            else
            {
                foreach (StockOut stockOut in stockOutList)
                {
                    stockOutManager.ItemUpdate(stockOut);
                    stockOutManager.StockOutDelete(stockOut);
                    //stockOutManager.SatesRecord(stockOut);

                }
                stockOutListGridView.DataSource = stockOutManager.GetAllStockOuts();
                stockOutListGridView.DataBind();
                outputLabel.Text = "Stock Out Successful";
            }
        }

        protected void lostButton_Click(object sender, EventArgs e)
        {
            List<StockOut> stockOutList = stockOutManager.GetAllStockOuts();
            if (stockOutList.Count == 0)
            {
                outputLabel.Text = "Add Items in the list first";
            }
            else
            {
                foreach (StockOut stockOut in stockOutList)
                {
                    stockOutManager.ItemUpdate(stockOut);
                    stockOutManager.StockOutDelete(stockOut);
                }
                stockOutListGridView.DataSource = stockOutManager.GetAllStockOuts();
                stockOutListGridView.DataBind();
                outputLabel.Text = "Stock Out Successful";
            }
        }
    }
}

