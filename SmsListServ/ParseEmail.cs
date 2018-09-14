namespace SmsListServ
{
    using System.IO;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Azure.WebJobs.Host;
    using Newtonsoft.Json;
    using Models.Email2;
    using System;

    public static class ParseEmail
    {
        [FunctionName("ParseEmail")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            var data = JsonConvert.DeserializeObject<Models.Email2.Body>(requestBody);

            AutoReply(data);

            return (ActionResult)new OkObjectResult(JsonConvert.SerializeObject(data));
        }

        private static void AutoReply(Body data)
        {
            data.Flip();
            SendEmail.SendEmail_Impl(data);
        }
    }
}
