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
            string sqlQuery = GetsqlQuery("GetCommnityInfo.txt");
            var response = mDapperSql.Query<Commodity>(mWebconfig.RDSSQLServerConnection, sqlQuery, null);
            return response.Cast<Commodity>();
        }

        // GET: api/Commodity/5
        [Route("{id:int}")]
        public Commodity Get(int id = -1)
        {
            return new Commodity()
            {
                code = "abc",
                name = "test",
                price = 1
            };
        }

        // POST: api/Commodity
        [HttpPost, Route("{id:int}")]
        public void Post(int id, Commodity commodity)
        {
            //todo
        }

        // PUT: api/Commodity/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Commodity/5
        public void Delete(int id)
        {
        }

        public string GetsqlQuery(string fileName)
        {
            var sqlquery = "";
            using (StreamReader sr = new StreamReader(HostingEnvironment.MapPath(mWebconfig.SqlQueryPath + fileName)))
            {
                // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();
                sqlquery = line.Replace(Environment.NewLine, "");
            }
            return sqlquery;
        }
    }
}
