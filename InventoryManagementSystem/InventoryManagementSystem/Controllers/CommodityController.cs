using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.utility;

namespace InventoryManagementSystem.Controllers
{
    [RoutePrefix("api/commodity")]
    public class CommodityController : ApiController
    {
        private Webconfig mWebconfig;
        private dapperSQL mDapperSql;

        public CommodityController()
        {
            mWebconfig = new Webconfig();
            mDapperSql = new dapperSQL();
        }
        // GET: api/Commodity
        [Route("")]
        public IEnumerable<Commodity> Get()
        {
            string sqlQuery = mDapperSql.GetsqlQuery("GetCommodityInfo.txt");
            var response = mDapperSql.Query<Commodity>(mWebconfig.RDSSQLServerConnection, sqlQuery);
            return response;
        }

        // GET: api/Commodity/5
        [Route("{id:int}")]
        public Commodity Get(int id)
        {
            string sqlQuery = mDapperSql.GetsqlQuery("GetSingleCommodityInfo.txt");
            var response = mDapperSql.Query<Commodity>(mWebconfig.RDSSQLServerConnection, sqlQuery, new {id});
            return response.FirstOrDefault();
        }

        // POST: api/Commodity
        [HttpPost, Route("")]
        public void Post(Commodity commodity)
        {
            string sqlQuery = mDapperSql.GetsqlQuery("InsertCommodityInfo.txt");
            mDapperSql.Execute(mWebconfig.RDSSQLServerConnection, sqlQuery, new
            {
                commodity.code,
                commodity.name,
                commodity.price
            });
        }

        // PUT: api/Commodity/5
        [HttpPut, Route("{id:int}")]
        public void Put(int id, Commodity commodity)
        {
            string sqlQuery = mDapperSql.GetsqlQuery("UpdateComminityInfo.txt");
            mDapperSql.Execute(mWebconfig.RDSSQLServerConnection, sqlQuery, new
            {
                id,
                commodity.code,
                commodity.name,
                commodity.price
            });
        }

        // DELETE: api/Commodity/5
        [HttpDelete, Route("{id:int}")]
        public void Delete(int id)
        {
            string sqlQuery = mDapperSql.GetsqlQuery("DeleteCommodityInfo.txt");
            mDapperSql.Execute(mWebconfig.RDSSQLServerConnection, sqlQuery, new { id });
        }

        
    }
}
