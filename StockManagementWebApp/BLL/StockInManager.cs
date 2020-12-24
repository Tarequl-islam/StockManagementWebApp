using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.BLL
{
    public class StockInManager
    {
        StockInGateway stockInGateway = new StockInGateway();

        public string Save(StockOut stockOut)
        {
            int roweffect = stockInGateway.ItemUpdate(stockOut);     //Save(stockOut);
            if (roweffect > 0)
            {
                return "Save Successful";
            }
            else
            {
                return "Save Failed";
            }

        }





    }
}