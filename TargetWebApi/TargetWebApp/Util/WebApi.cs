using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace TargetWebApp.Util
{
    public class WebApi
    {
        public static string URI = "https://localhost:44352/api/";
        public static string TOKEN = "";

        
        public static string Request_GET_Pesquisa(string endPoint, Dictionary<string, string> parameters)
        {
            return Request_GET_PESQUISA(endPoint, parameters, "GET");
        }

        private static string Request_GET_PESQUISA(string endPoint, Dictionary<string, string> parameters, string method)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + endPoint);
            request.ServicePoint.Expect100Continue = false;

            if(parameters != null && parameters.Count > 0)
            {
                foreach (var par in parameters)
                {
                    request.Headers.Add(par.Key, par.Value);
                }
            }

            request.Method = method;
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }

       
        public static string Request_GET(string endPoint, string parameter)
        {
            return Request_GET_DELETE(endPoint, parameter, "GET");
        }

        public static string Request_DELETE(string endPoint, string parameter)
        {
            return Request_GET_DELETE(endPoint, parameter, "DELETE");
        }

        private static string Request_GET_DELETE(string endPoint, string parameter, string method)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + endPoint + parameter);
            request.ServicePoint.Expect100Continue = false;
            request.Headers.Add("Token", TOKEN);
            request.Method = method;
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new System.IO.StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }


        public static string Request_PUT(string endPoint, string jsonData)
        {
            return Request_POST_PUT(endPoint, jsonData, "PUT");
        }

        public static string Request_POST(string endPoint, string jsonData)
        {
            return Request_POST_PUT(endPoint, jsonData, "POST");
        }

        private static string Request_POST_PUT(string endPoint, string jsonData, string method)
        {
            var request = (HttpWebRequest)WebRequest.Create(URI + endPoint);
            var data = Encoding.UTF8.GetBytes(jsonData);
            request.Method = method;
            request.Headers.Add("Token", TOKEN);
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;
        }
    }
}