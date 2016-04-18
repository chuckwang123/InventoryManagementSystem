using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.utility;
using InventoryManagementSystem.Utility.Helper;

namespace InventoryManagementSystem.Controllers
{
    [RoutePrefix("api/Stock")]
    public class StockController : ApiController
    {
        private dapperSQL mDapperSql = new dapperSQL();
        private Webconfig mWebconfig = new Webconfig();
        private CommodityHelper mCommodityHelper = new CommodityHelper();

        // GET: api/Stock
        [Route("")]
        public IEnumerable<Stock> GetStocks()
        {
            string sqlQuery = mDapperSql.GetsqlQuery("GetStockInfo.txt");
            var responses = mDapperSql.Query<StockDTO>(mWebconfig.RDSSQLServerConnection, sqlQuery);
            var StockResponses = new List<Stock>();
            foreach (var response in responses)
            {
                var stockReponse = new Stock(response);
                stockReponse.commodity = mCommodityHelper.GetSingleCommodity(response.commodityID);
                StockResponses.Add(stockReponse);
            }
            return StockResponses;
        }

        // GET: api/Stock/5
        [Route("{id:int}")]
        public Stock GetStock(int id)
        {
            string sqlQuery = mDapperSql.GetsqlQuery("GetSingleStockInfo.txt");
            var response = mDapperSql.Query<StockDTO>(mWebconfig.RDSSQLServerConnection, sqlQuery, new {id});

            var stockReponse = new Stock(response.FirstOrDefault());
            stockReponse.commodity = mCommodityHelper.GetSingleCommodity(response.FirstOrDefault().commodityID);
            return stockReponse;
        }

        // POST: api/Stock
        [HttpPost, Route("")]
        public void PostStock(Stock stock)
        {
            stock.SetupStock();
            string sqlQuery = mDapperSql.GetsqlQuery("InsertStockInfo.txt");
            mDapperSql.Execute(mWebconfig.RDSSQLServerConnection, sqlQuery, new
            {
                stock.Date,
                stock.commodity.id,
                stock.number,
                stock.TotalPrice 
            });
        }

        // PUT: api/Stock/5
        [HttpPut, Route("{id:int}")]
        public void PutStock(int id, Stock stock)
        {
            var commodityID = stock.commodity.id;
            stock.SetupStock();
            string sqlQuery = mDapperSql.GetsqlQuery("UpdateStockInfo.txt");
            mDapperSql.Execute(mWebconfig.RDSSQLServerConnection, sqlQuery, new
            {
                id,
                stock.Date,
                commodityID,
                stock.number,
                stock.TotalPrice
            });
        }

        // DELETE: api/Stock/5
        [HttpDelete, Route("{id:int}")]
        public void DeleteStock(int id)
        {
            string sqlQuery = mDapperSql.GetsqlQuery("DeleteStockInfo.txt");
            mDapperSql.Execute(mWebconfig.RDSSQLServerConnection, sqlQuery, new { id });
        }

        
    }
}
