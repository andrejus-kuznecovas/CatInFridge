using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Json;
using System.Text;

namespace LoginSystem
{
    public class ReceiptAPI : IAPIConfiguration
    {
        /// <summary>
        /// Creates new receipt in the database
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="token"></param>
        /// <param name="receiptJSON"></param>
        /// <returns></returns>
        public  async Task<JsonObject> SaveReceiptData(int ID, string token, string receiptJSON)
        {
            var endpoint = String.Format("receipts/add/user/{0}/token/{1}", ID, token, receiptJSON);
            var request = FormRequest(endpoint, "POST");

            UTF8Encoding encoding = new UTF8Encoding();


            string body = String.Format("user={0}&token={1}&receipt={2}", ID, token, Uri.EscapeUriString(receiptJSON));
            byte[] bytes = encoding.GetBytes(Uri.EscapeUriString(body));
            request.ContentLength = bytes.Length;
            Stream requestStream = request.GetRequestStream();

            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            JsonObject userJson = await MakeRequest(request);

            if (CheckForSuccess(userJson))
            {
                return userJson;
            }

            return null;
        }

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


        public bool CheckForSuccess(JsonObject data)
        {
            // Server should return JSON object containing field "success", which indicates whether the request was successful
            bool succeeded = Boolean.Parse(data["success"].ToString());

            return succeeded;
        }

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
    }
}