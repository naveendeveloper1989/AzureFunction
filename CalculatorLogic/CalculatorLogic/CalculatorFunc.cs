using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CalculatorLogic
{
    public static class CalculatorFunc
    {
        [FunctionName("CalculatorFunc")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            int result = 0;
            try
            {
                int no1 = int.Parse(req.Query["no1"]);
                int no2 = int.Parse(req.Query["no2"]);
                string operation = req.Query["opcode"];
                
                if (operation == "add")
                {
                    result = no1 + no2;
                }
            }
            catch
            {
                return new BadRequestObjectResult("Something Went Wrong");

            }
            return (ActionResult)new OkObjectResult($"Hello, {result}");
            


        }
    }
}
