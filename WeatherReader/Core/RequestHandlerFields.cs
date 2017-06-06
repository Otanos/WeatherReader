using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReader.Core
{
    public abstract class RequestHandlerFields
    {
        protected static string response;

        protected static string url = "http://api.openweathermap.org/data/2.5/group?id={0}&APPID=caf8e2da79fd425194639197386ca29e";

        protected static readonly HttpClient client = new HttpClient();

        protected static HttpWebRequest httpWebRequest;

        protected static HttpWebResponse httpWebResponse;
    }
}
