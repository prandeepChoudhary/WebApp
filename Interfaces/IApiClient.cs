using RestSharp;

namespace WebApp.Interfaces
{
    public interface IApiClient
    {
        RestResponse Call(string URL, string Method, string Json = "");
    }
}
