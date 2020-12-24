using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.BLL
{
  
    public class ViewSalesManager
    {
        ViewSalesGateway viewSalesGateway = new ViewSalesGateway();

        public List<StockOut> GetAllSatesRecord(SalesDate date)
        {
            return viewSalesGateway.GetAllSatesRecord(date);
        }
    }
}