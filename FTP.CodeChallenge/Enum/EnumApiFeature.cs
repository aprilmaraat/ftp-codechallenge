using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace FTP.CodeChallenge
{
    public enum EnumApiFeature
    {
        [Description("current")]
        Current,
        [Description("historical")]
        HistoricalWeather,
        [Description("forecast")]
        WeatherForecast,
        [Description("autocomplete")]
        LocationLookup
    }
}
