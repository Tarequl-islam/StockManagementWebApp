using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.DAL.Model
{
    public class ItemsView
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int AvailableQuantity { get; set; }
        public int ReorderLevel { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public int CompanyId { get; set; }
    }
}