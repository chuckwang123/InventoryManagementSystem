using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.utility;

namespace InventoryManagementSystem.Controllers
{
    [RoutePrefix("api/Stock")]
    public class StockController : ApiController
    {
        private dapperSQL mDapperSql = new dapperSQL();
        private Webconfig mWebconfig = new Webconfig();

        // GET: api/Stock
        [Route("")]
        public IEnumerable<Stock> Get()
        {
            string sqlQuery = mDapperSql.GetsqlQuery("GetStockInfo.txt");
            var response = mDapperSql.Query<Stock>(mWebconfig.RDSSQLServerConnection, sqlQuery);
            return response;
        }

        // GET: api/Stock/5
        [Route("{id:int}")]
        public Stock Get(int id)
        {
            string sqlQuery = mDapperSql.GetsqlQuery("GetSingleStockInfo.txt");
            var response = mDapperSql.Query<Stock>(mWebconfig.RDSSQLServerConnection, sqlQuery, new {id});
            return response.FirstOrDefault();
        }

        // POST: api/Stock
        [HttpPost, Route("")]
        public void Post(Stock stock)
        {
            stock.setupStock();
            string sqlQuery = mDapperSql.GetsqlQuery("InsertStockInfo.txt");
            mDapperSql.Execute(mWebconfig.RDSSQLServerConnection, sqlQuery, new
            {
                stock.Date,
                stock.commodityID,
                stock.number,
                stock.TotalPrice 
            });
        }

        // PUT: api/Stock/5
        [HttpPut, Route("{id:int}")]
        public void Put(int id, Stock stock)
        {
            stock.setupStock();
            string sqlQuery = mDapperSql.GetsqlQuery("UpdateStockInfo.txt");
            mDapperSql.Execute(mWebconfig.RDSSQLServerConnection, sqlQuery, new
            {
                id,
                stock.Date,
                stock.commodityID,
                stock.number,
                stock.TotalPrice
            });
        }

        // DELETE: api/Stock/5
        [HttpDelete, Route("{id:int}")]
        public void Delete(int id)
        {
            string sqlQuery = mDapperSql.GetsqlQuery("DeleteStockInfo.txt");
            mDapperSql.Execute(mWebconfig.RDSSQLServerConnection, sqlQuery, new { id });
        }

        
    }
}
