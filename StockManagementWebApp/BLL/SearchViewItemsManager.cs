using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagementProjectApp.DAL.Gateway;
using StockManagementWebApp.DAL.Model;

namespace StockManagementProjectApp.BLL
{
    
    public class SearchViewItemsManager
    {
        SearchViewItemGateway searchViewItemGateway = new SearchViewItemGateway();

        private SearchViewItemGateway searchAndViewGateway = new SearchViewItemGateway();

        public List<ItemsView> GetItemsByCompanyIdAndCategoryId(int companyId, int categoryId)
        {
            return searchAndViewGateway.GetItemsByCompanyIdAndCategoryId(companyId, categoryId);
        }

        public List<ItemsView> GetItemsByCategoryId(int categoryId)
        {
            return searchAndViewGateway.GetItemsByCategoryId(categoryId);
        }

        public List<ItemsView> GetItemsByCompanyId(int companyId)
        {
            return searchAndViewGateway.GetItemsByCompanyId(companyId);
        }

    }
}