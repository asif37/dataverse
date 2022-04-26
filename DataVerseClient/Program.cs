using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
namespace DataVerseClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // e.g. https://yourorg.crm.dynamics.com
            string url = "https://org5df8ed78.crm4.dynamics.com";
            // e.g. you@yourorg.onmicrosoft.com
            string userName = "xxxxxxxxx@xxxx.onmicrosoft.com";
            // e.g. y0urp455w0rd 
            string password = "xxxxx";

            string conn = $@"
    Url = {url};
    AuthType = OAuth;
    UserName = {userName};
    Password = {password};
    AppId = 51f81489-12ee-4a9e-aaae-a2591f45987d;
    RedirectUri = app://58145B91-0C36-4500-8554-080854F2AC97;
    LoginPrompt=Auto;
    RequireNewInstance = True";

            using (var svc = new CrmServiceClient(conn))
            {
                 WhoAmIRequest request = new WhoAmIRequest();

                WhoAmIResponse response = (WhoAmIResponse)svc.Execute(request);

                Console.WriteLine("Your UserId is {0}", response.UserId);

                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
        }
    }
}
