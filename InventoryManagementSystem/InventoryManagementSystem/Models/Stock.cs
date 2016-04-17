using System;
using InventoryManagementSystem.Controllers;

namespace InventoryManagementSystem.Models
{
    public class Stock
    {
        public int id { get; set; }
        public string Date { get; set; }
        public int commodityID { get; set; }
        public int number { get; set; }
        public double TotalPrice { get; set; }

        public void setupStock()
        {
            CommodityController mCommodityController = new CommodityController();
            Commodity model = mCommodityController.Get(commodityID);

            TotalPrice = model.price * number;
            if (string.IsNullOrEmpty(Date))
            {
                Date = DateTime.Now.ToString();
            }
        }
    }
}