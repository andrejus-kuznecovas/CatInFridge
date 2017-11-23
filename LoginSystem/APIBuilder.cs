using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Json;


namespace LoginSystem
{
    public class APIBuilder
    {
        private IAPIConfiguration _apiConfiguration;

        public APIBuilder(IAPIConfiguration apiConfiguration)
        {
            apiConfiguration = new UserAPIAuthentification();
            //apiConfiguration = new ReceiptAPI();


            /*this._apiConfiguration = apiConfiguration;
            _apiConfiguration.CheckForSuccess(data);
            _apiConfiguration.MakeRequest(request);
            _apiConfiguration.FormRequest(url, method);

            //*/
        }
       
        }
}