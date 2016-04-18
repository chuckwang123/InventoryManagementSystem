using System.Collections.Generic;
using System.Linq;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.utility;

namespace InventoryManagementSystem.Utility.Helper
{
    public class CommodityHelper
    {
        private Webconfig mWebconfig;
        private dapperSQL mDapperSql;

        public CommodityHelper()
        {
            mWebconfig = new Webconfig();
            mDapperSql = new dapperSQL();
        }

        public Commodity GetSingleCommodity(int id = -1)
        {
            string sqlQuery = mDapperSql.GetsqlQuery("GetSingleCommodityInfo.txt");
            var response = mDapperSql.Query<Commodity>(mWebconfig.RDSSQLServerConnection, sqlQuery, new { id });
            return response.FirstOrDefault();
        }

        public IEnumerable<Commodity> GetCommodities()
        {
            string sqlQuery = mDapperSql.GetsqlQuery("GetCommodityInfo.txt");
            var response = mDapperSql.Query<Commodity>(mWebconfig.RDSSQLServerConnection, sqlQuery);
            return response;
        }
    }
}