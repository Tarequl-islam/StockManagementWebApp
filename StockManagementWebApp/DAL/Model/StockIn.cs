using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagementProjectApp.DAL.Models
{
    [Serializable]
    public class StockIn
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ItemId { get; set; }
        public int StockQuantity { get; set; }
        public int Available { get; set; }
        

    }
}