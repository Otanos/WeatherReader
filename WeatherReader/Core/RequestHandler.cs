using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

namespace WeatherReader.Core
{
    public class RequestHandler:RequestHandlerFields
    {
        public static string GetResponse
        {
            get { return response; }
        }

        public static void GetWeather(string cityId)
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format(url, cityId));

            httpWebRequest.Method = "GET";

            httpWebRequest.MaximumAutomaticRedirections = 3;

            httpWebRequest.Timeout = 5000;

            httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            var responseStream = httpWebResponse.GetResponseStream();

            if (responseStream != null)
            {
                var streamReader = new StreamReader(responseStream);

                response = streamReader.ReadToEnd().ToString();
            }
            
            if (responseStream != null)
            {
                responseStream.Close();
            }
        }
    }
}
