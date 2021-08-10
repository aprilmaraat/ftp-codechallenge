using System;
using System.Collections.Generic;
using System.Text;

namespace FTP.CodeChallenge
{
    public class WeatherStackData
    {
        public Request request { get; set; }
        public Location location { get; set; }
        public Current current { get; set; }
    }

    public class Request 
    {
        public string type { get; set; }
        public string query { get; set; }
        public string language { get; set; }
        public string unit { get; set; }
    }

    public class Location 
    {
        public string name { get; set; }
        public string country { get; set; }
        public string region { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone_id { get; set; }
        public string localtime { get; set; }
        public int localtime_epoch { get; set; }
        public string utc_offset { get; set; }
    }

    public class Current 
    {
        public string observation_time { get; set; }
        public double temperature { get; set; }
        public int weather_code { get; set; }
        public string[] weather_icons { get; set; }
        public string[] weather_descriptions { get; set; }
        public double wind_speed { get; set; }
        public double wind_degree { get; set; }
        public string wind_dir { get; set; }
        public double pressure { get; set; }
        public double precip { get; set; }
        public double humidity { get; set; }
        public double cloudcover { get; set; }
        public double feelslike { get; set; }
        public double uv_index { get; set; }
        public double visibility { get; set; }
        public string is_day { get; set; }
    }
}
