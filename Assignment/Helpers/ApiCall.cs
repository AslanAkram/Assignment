//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Web;

//namespace Assignment.Helpers
//{
//    public class ApiCall: ICallAPI
//    {
//        public string APIurl { get; private set; }
//        private readonly IConfiguration configration;
//        private WebClient _client;
//        public CallAPI(IConfiguration _configration)
//        {
//            configration = _configration;
//            APIurl = configration.GetSection("APIurl").Value;
//            _client = new WebClient();
//            ServicePointManager
//                    .ServerCertificateValidationCallback +=
//                    (sender, cert, chain, sslPolicyErrors) => true;

//        }
//        public string Get(string url, string pram = "")
//        {

//            return _client.DownloadString(APIurl + url + pram);
//        }


//    }
//    public interface ICallAPI
//    {

//        string Get(string url, string pram = "");
//    }
//}
//}