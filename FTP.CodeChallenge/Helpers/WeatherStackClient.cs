using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace FTP.CodeChallenge
{
    public class WeatherStackClient
    {
        private const string AccessKey = "d9882ed394cfc2b1fdd84a8971ffa6dd";
        private const string BaseUrl = "http://api.weatherstack.com";

        public async Task<WeatherStackData> GetWeatherStackData(string apiFeature, string query)
        {
            var req_string = $"{BaseUrl}/{apiFeature}?access_key={AccessKey}&query={query}";
            var req = (HttpWebRequest)WebRequest.Create(req_string);
            req.Method = "GET";
            req.ContentType = "application/json";
            req.UserAgent = "request";

            try
            {
                using HttpWebResponse response = await req.GetResponseAsync() as HttpWebResponse;
                if (response == null) return null;

                Encoding encoding = Encoding.GetEncoding("utf-8");

                StreamReader reader =
                    new StreamReader(
                        response.GetResponseStream() ?? throw new InvalidOperationException(), encoding);
                var ApiStatus = reader.ReadToEnd();
                var data = JsonConvert.DeserializeObject<WeatherStackData>(ApiStatus);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Current> GetCurrentWeatherForecast(string query) 
        {
            var result = GetWeatherStackData(EnumHelper.GetEnumDescription(EnumApiFeature.Current), query);
            return result.Result.current;
        }
    }
}
