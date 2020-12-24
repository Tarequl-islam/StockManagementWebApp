using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementProjectApp.DAL.Models
{
    public class SearchViewItems
    {

        public int Id { get; set; }
        public string ItemName { get; set; }
        public string ComapanyName { get; set; }
        public int AvailableQuantity { get; set; }
        public int ReorderLevel { get; set; }

    }
}