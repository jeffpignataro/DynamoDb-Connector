using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using commitment_database_connector.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace commitment_database_connector.Controllers
{
    public class DynamoController : Controller
    {
        private static AmazonDynamoDBClient DynamoDbClient = new AmazonDynamoDBClient();

        public async Task<IActionResult> ListTables()
        {
            List<string> tableList = new List<string>();
            var listTablesResponse = await DynamoDbClient.ListTablesAsync();
            tableList = listTablesResponse.TableNames;
            return View(tableList);
        }
        public async Task<IActionResult> DescribeTable(string TableName)
        {
            var TableNameWithPrefix = TableName;
            if (TableNameWithPrefix.Contains(Helpers.NamingHelpers.DynamoTablePrefix) == false)
            {
                TableNameWithPrefix = Helpers.NamingHelpers.DynamoTablePrefix + TableNameWithPrefix;
            }
            var describeTableResponse = await DynamoDbClient.DescribeTableAsync(TableNameWithPrefix);
            return View(describeTableResponse.Table);
        }

        public async Task<IActionResult> GetItems(string TableName)
        {
            var attributesToGet = new List<string>();
            attributesToGet.Add("Id");
            attributesToGet.Add("Data");
            var scanResponse = await DynamoDbClient.ScanAsync(TableName, attributesToGet);
            return View(scanResponse);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
