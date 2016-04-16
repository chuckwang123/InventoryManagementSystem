using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace InventoryManagementSystem.utility
{
    public class dapperSQL
    {
        public dapperSQL() { }

        public IEnumerable<T> Query<T>(string connection, string sql, params object[] parameter)
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
    }
}