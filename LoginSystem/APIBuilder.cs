﻿using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Json;


namespace LoginSystem
{
    public class APIBuilder
    {
        private IAPIConfiguration _apiConfiguration;

        public APIBuilder(IAPIConfiguration apiConfiguration, WebRequest request, JsonObject data, string url, string method)
        {
            this._apiConfiguration = apiConfiguration;
            _apiConfiguration.CheckForSuccess(data);
            _apiConfiguration.MakeRequest(request);
            _apiConfiguration.FormRequest(url, method);

            //
        }
        /*
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
    }*/
}
}