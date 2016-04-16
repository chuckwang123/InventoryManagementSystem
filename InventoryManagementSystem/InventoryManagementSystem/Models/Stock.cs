using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class Stock
    {
        public Commodity Commodity { get; set; }
        public int count { get; set; }
        public DateTime Date { get; set; }
        public double TotalPrice { get; set; }

        public Stock()
        {
            TotalPrice = count*Commodity.price;
        }
    }
}