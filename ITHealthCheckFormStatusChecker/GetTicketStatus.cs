using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHealthCheckFormStatusChecker
{
    class GetTicketStatus
    {
        public string GetStatusOfRequestsAsync(string TicketId)
        {
            try
            {
                var basePath = ConfigurationManager.AppSettings["apiuri"];
                var apikey = ConfigurationManager.AppSettings["APIKey"];
                //var input_data = JsonConvert.SerializeObject(objData);
                var client = new RestClient();
                var requestUri = basePath + '/' + TicketId;
                var request = new RestRequest(requestUri, Method.Get);
                request.AddHeader("authtoken", apikey);
                var response = client.Execute(request);
                return response.Content;
            }

            catch(Exception ex)
            {
                return null;
            }

        }

    }
}
