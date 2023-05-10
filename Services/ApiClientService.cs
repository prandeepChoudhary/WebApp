using Microsoft.AspNetCore.DataProtection.KeyManagement;
using RestSharp;
using WebApp.Interfaces;

namespace WebApp.Services
{
    public class ApiClientService : IApiClient
    {
        private readonly string ContentTypeJson = "application/json; charset=utf-8";
        private readonly string baseurl = "https://localhost:7000/api/";
        private readonly RestClient restClient = new RestClient("https://localhost:7000/api/");
        public RestSharp.RestResponse Call(string URL, string Method = "GET", string Json = "")
        {
            RestRequest restRequest = new();
            if (Method.ToUpper() == "GET")
                restRequest = new RestRequest(URL, RestSharp.Method.Get);
            else
                restRequest = new RestRequest(URL, RestSharp.Method.Post);

            restRequest.AddHeader("content-type", "application/json");
            if (!string.IsNullOrEmpty(Json))
            {
                restRequest.AddParameter(ContentTypeJson, Json, ParameterType.RequestBody);
                restRequest.RequestFormat = DataFormat.Json;
            }
            var response = restClient.Execute(restRequest);

            //var client = new RestClient();
            //var request = new RestRequest("http://localhost:7000/WeatherForecast", RestSharp.Method.Get);
            //RestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);


            return response;
        }


    }
}
