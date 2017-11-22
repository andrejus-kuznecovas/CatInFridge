using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Json;

namespace LoginSystem
{
    public class UserAPIAuthentification : IAPIConfiguration
    {

        /// <summary>
        /// Makes asynchronous Login request to the server to get User ID and token from server
        /// </summary>
        /// <param name="username">Username to login with</param>
        /// <param name="password">Password to login with</param>
        /// <returns>JSON object containing user data if Login operation was successful</returns>
        public async Task<JsonObject> LoginRequest(string username, string password)
        {
            var endpoint = String.Format("login/username/{0}/password/{1}", username, password);
            var request = FormRequest(endpoint, "GET");

            JsonObject userJson = await MakeRequest(request);

            if (CheckForSuccess(userJson))
            {
                return userJson;
            }

            return null;
        }


        /// <summary>
        /// Makes asynchronous Registration request to the server and gets User ID and token from server
        /// </summary>
        /// <param name="email">Email to register with</param>
        /// <param name="username">Username to register with</param>
        /// <param name="password">Password to register with</param>
        /// <returns>JSON object containing user data if Login operation was successful</returns>
        public  async Task<JsonObject> RegistrationRequest
            (string email, string username, string password)
        {
            // Save all the registration fields in a single array of objects
            var parameters = new object[] {email, username, password };
            var endpoint = String.Format("register/email/{0}/username/{1}/password/{2}", parameters);
            var request = FormRequest(endpoint, "GET");

            JsonObject userJson = await MakeRequest(request);

            if (CheckForSuccess(userJson))
            {
                return userJson;
            }
            return null;
        }
        /// <summary>
        /// Makes asynchronous request to get User information from the server
        /// </summary>
        /// <param name="id">Unique ID of a user</param>
        /// <param name="token">Unique token of a user</param>
        /// <returns>User info JSON object if request was successful</returns>
        public  async Task<JsonObject> GetInfo(int id, string token)
        {

            var endpoint = String.Format("info/user/{0}/token/{1}", id.ToString(), token);
            var request = FormRequest(endpoint, "GET");

            JsonObject userJson = await MakeRequest(request);

            if (CheckForSuccess(userJson))
            {
                return userJson;
            }
            return null;

        }


    

        //Server name to avoid repetition
         protected static string baseURL = "URL TO BE HERE :)";

            /// <summary>
        /// Does a request to server
        /// </summary>
        /// <param name="request">Request object</param>
        /// <returns>User data if request was successfuly completed</returns>
        public async Task<JsonObject> MakeRequest(WebRequest request)
    {
        using (WebResponse response = await request.GetResponseAsync())
        {
            using (Stream stream = response.GetResponseStream())
            {
                // Save server response to JSON object
                var jsonResponse = await Task.Run(() => JsonObject.Load(stream));
                var userJson = jsonResponse as JsonObject; // End Object

                return userJson;
            }
        }
    }

    /// <summary>
    /// Used to check whether request data is correct
    /// </summary>
    /// <param name="data">JSON Object - data from the server</param>
    /// <returns></returns>
    public bool CheckForSuccess(JsonObject data)
    {
        // Server should return JSON object containing field "success", which indicates whether the request was successful
        bool succeeded = Boolean.Parse(data["success"].ToString());

        return succeeded;
    }


    /// <summary>
    /// Forms request with specified endpoint and method
    /// </summary>
    /// <param name="url"></param>
    /// <param name="method"></param>
    /// <returns></returns>
    public WebRequest FormRequest(string url, string method)
    {
        var request = HttpWebRequest.Create(
            new Uri(baseURL + url)
        );

        switch (method)
        {
            case "GET":
                request.Method = "GET";
                break;
            case "POST":
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                break;
            case "PUT":
                request.Method = "PUT";
                request.ContentType = "application/x-www-form-urlencoded";
                break;
        }

        return request;

    }


    public enum RequestType
{
    LOGIN, REGISTER, GET_INFO
}
}
}