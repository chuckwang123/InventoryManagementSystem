using System.Web.Http;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    [RoutePrefix("")]
    public class InfoController : ApiController
    {
        // GET: api/Info
        [Route("")]
        public APIInfo Get()
        {
            string title = "Welcome to the Inventory Management System";

            return new APIInfo
            {
                Controller = "Inventory Management System",
                Version = "1.0.0.0",
                Links = new LinksDictionary<string, string>
                {
                    {"Commodity Controller","api/commodity" },
                    {"Stock Controller","api/Stock" }
                }
            };
        }

    }
}
