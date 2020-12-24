using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementWebApp.DAL.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Available { get; set; }
        public int Reorder { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        
    }
}