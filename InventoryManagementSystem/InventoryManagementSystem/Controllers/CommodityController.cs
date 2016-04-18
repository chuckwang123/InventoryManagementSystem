using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.UI.WebControls.WebParts;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.utility;
using InventoryManagementSystem.Utility.Helper;

namespace InventoryManagementSystem.Controllers
{
    [RoutePrefix("api/commodity")]
    public class CommodityController : ApiController
    {
        private Webconfig mWebconfig;
        private dapperSQL mDapperSql;
        private CommodityHelper mCommodityHelper;

        public CommodityController()
        {
            mWebconfig = new Webconfig();
            mDapperSql = new dapperSQL();
            mCommodityHelper = new CommodityHelper();
        }
        // GET: api/Commodity
        [Route("")]
        public IEnumerable<Commodity> GetCommodities()
        {
            return mCommodityHelper.GetCommodities();
        }

        // GET: api/Commodity/5
        [Route("{id:int}")]
        public Commodity GetSingleCommodity(int id = -1)
        {
           return mCommodityHelper.GetSingleCommodity(id);
        }

        // POST: api/Commodity
        [HttpPost, Route("")]
        public void PostCommodity(Commodity commodity)
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
        public void PutCommodity(Commodity commodity, int id = -1)
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
        public void DeleteCommodity(int id = -1)
        {
            string sqlQuery = mDapperSql.GetsqlQuery("DeleteCommodityInfo.txt");
            mDapperSql.Execute(mWebconfig.RDSSQLServerConnection, sqlQuery, new { id });
        }

        
    }
}
