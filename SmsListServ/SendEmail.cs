namespace SmsListServ
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.IO;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Azure.WebJobs.Host;
    using Newtonsoft.Json;

    public static class SendEmail
    {
        //todo:
        [FunctionName("SendEmail")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = new StreamReader(req.Body).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            return name != null
                ? (ActionResult)new OkObjectResult($"Hello, {name}")
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }

        //todo:implement echo, but annotate w/ todos
        public static void SendEmail_Impl(Models.Email2.Body emailData)
        {
            var pass = Environment.GetEnvironmentVariable(emailData.From);
            //todo: precondition
            //var pass = keyvault[todo@fromParam];

            try
            {
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = new NetworkCredential("todo@fromParam", "pass")
                };

                var msg = new MailMessage()
                {
                    From = new MailAddress("todo@fromParam"),
                    // Subject = "Test email.", does it default to empty string?
                    Body = "todoMessageParam",
                    IsBodyHtml = false
                    //todo: attachments
                };

                // todo: loop
                msg.To.Add(new MailAddress("todo@toParam.com"));
                client.Send(msg);
            }
            catch (Exception e)
            {
                //todo: jsonify object and return it w/ 500 error code
                Console.WriteLine(e.Message);
            }
        }
    }
}
