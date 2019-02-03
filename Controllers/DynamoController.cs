using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using commitment_database_connector.Models;
using Amazon.DynamoDBv2;

namespace commitment_database_connector.Controllers
{
    public class DynamoController : Controller
    {
        private static AmazonDynamoDBClient DynamoDbClient = new AmazonDynamoDBClient();

        public IActionResult Index()
        {
            List<string> tableList = new List<string>();
            using (var ListTablesResult = DynamoDbClient.ListTablesAsync())
            {
                tableList = ListTablesResult.Result.TableNames;
            }
            return View(tableList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
