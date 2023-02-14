using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ITHealthCheckFormStatusChecker.InputOutputModel;

namespace ITHealthCheckFormStatusChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager dataManager = new DataManager();
            GetTicketStatus getTicketStatus = new GetTicketStatus();
            List<KeyValuePair<string, string>> responselist = new List<KeyValuePair<string, string>>();

            List<string> TicketId  = dataManager.FetchData();

            foreach (var element in TicketId)
            {
                var response = getTicketStatus.GetStatusOfRequestsAsync(element);
                var data = (JObject)JsonConvert.DeserializeObject(response);
                responselist.Add(new KeyValuePair<string, string>(element, (string)data.SelectToken("request.status.name")));
            }

            dataManager.WriteData(responselist);
           
        }
    }
}
