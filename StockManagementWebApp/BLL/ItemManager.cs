using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementWebApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementWebApp.BLL
{
    public class ItemManager
    {
        ItemsGateway itemGateway = new ItemsGateway();

        public string Save(Item item)
        {
            if (itemGateway.IsNameExist(item.Name, item.CategoryId, item.CompanyId))
            {
                return "Items of this company and same category already Exist. Please retry";
            }
            else
            {
                int rowAffect = itemGateway.Save(item);
                if (rowAffect > 0)
                {
                    return "Save Successfull";
                }
                else
                {
                    return "Save Failed";
                }
            }

        }
        public List<Item> GetAllItems()
        {
            return itemGateway.GetAllItems();
        }
    }
}