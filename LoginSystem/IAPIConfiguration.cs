using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Json;


namespace LoginSystem
{
    interface IAPIConfiguration
    {
        Task<JsonObject> MakeRequest(WebRequest request);
       
        bool CheckForSuccess(JsonObject data);

        WebRequest FormRequest(string url, string method);
    }
}