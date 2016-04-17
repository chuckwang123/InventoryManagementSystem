using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Web.Hosting;
using Dapper;

namespace InventoryManagementSystem.utility
{
    public class dapperSQL
    {
        private Webconfig mWebconfig = new Webconfig();

        public IEnumerable<T> Query<T>(string connection, string sql, object parameter = null)
        {
            IEnumerable<T> response;
            using (var sqlConnection =new SqlConnection(connection))
            {
                sqlConnection.Open();

                response = sqlConnection.Query<T>(sql,parameter);
                
                sqlConnection.Close();
            }

            return response;
        }

        public void Execute(string connection, string sql, object parameter = null)
        {
            using (var sqlConnection = new SqlConnection(connection))
            {
                sqlConnection.Open();

                sqlConnection.Query(sql, parameter);

                sqlConnection.Close();
            }
        }

        public string GetsqlQuery(string fileName)
        {
            var sqlquery = "";
            using (StreamReader sr = new StreamReader(HostingEnvironment.MapPath(mWebconfig.SqlQueryPath + fileName)))
            {
                String line = sr.ReadToEnd();
                sqlquery = line.Replace(Environment.NewLine, "");
            }
            return sqlquery;
        }
    }
}