using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class StockDTO
    {
        public int id { get; set; }
        public string Date { get; set; }
        public int commodityID { get; set; }
        public int number { get; set; }
        public double TotalPrice { get; set; }
    }
}