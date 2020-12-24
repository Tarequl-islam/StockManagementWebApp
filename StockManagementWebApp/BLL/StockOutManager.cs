using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.BLL
{
    public class StockOutManager
    {
        private StockOutGateway stockOutGateway = new StockOutGateway();

        public List<Item> GetAllSelectedItems(int companyId)
        {
            return stockOutGateway.GetAllSelectedItems(companyId);
        }

        public string Save(StockOut stockOut)
        {

            if (stockOutGateway.IsNameExist(stockOut.CompanyId, stockOut.ItemId))
            {
                int roweffect = stockOutGateway.Update(stockOut);
                if (roweffect > 0)
                {
                    return "Save Successful";
                }
                else
                {
                    return "Save Failed";
                }
            }
            else
            {
                int roweffect = stockOutGateway.Save(stockOut);
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

        public List<StockOut> GetAllStockOuts()
        {
            return stockOutGateway.GetAllStockOuts();
        }

        public int ItemUpdate(StockOut stockOutt)
        {
            return stockOutGateway.ItemUpdate(stockOutt);
        }

        public int StockOutDelete(StockOut stockOut3)
        {
            return stockOutGateway.StockOutDelete(stockOut3);
        }

        public int SatesRecord(StockOut stockOutItem)
        {
            return stockOutGateway.SatesRecord(stockOutItem);
        }
    }
}