using System;
using System.Web.UI.WebControls.WebParts;
using InventoryManagementSystem.Controllers;

namespace InventoryManagementSystem.Models
{
    public class Stock
    {
        public int id { get; set; }
        public string Date { get; set; }
        public Commodity commodity { get; set; }
        public int number { get; set; }
        public double TotalPrice { get; set; }

        public Stock(StockDTO dto)
        {
            id = dto.id;
            Date = dto.Date;
            number = dto.number;
            TotalPrice = dto.TotalPrice;
            commodity = new Commodity();
        }

        public void SetupStock()
        {
            TotalPrice = commodity.price * number;
            if (string.IsNullOrEmpty(Date))
            {
                Date = DateTime.Now.ToString();
            }
        }
    }
}