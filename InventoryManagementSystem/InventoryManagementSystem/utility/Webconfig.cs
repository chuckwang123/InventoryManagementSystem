using System.Configuration;

namespace InventoryManagementSystem.utility
{
    public class Webconfig
    {
        public string RDSSQLServerConnection
        {
            get{return ConfigurationManager.ConnectionStrings["RDSSQLServerConnection"].ConnectionString;}
        }

        public string SqlQueryPath
        {
            get { return ConfigurationManager.AppSettings["SqlQueryPath"]; }
        }
    }
}