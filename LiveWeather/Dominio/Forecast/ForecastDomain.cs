using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Domain.Forecast
{
    public class ForecastDomain
    {
        [JsonProperty("weather")]
        public IEnumerable<WeatherDomain> Weather { get; set; }
        [JsonProperty("dt")]
        public double DataUnixTime { get; set; }
        public DateTime Date => _ConvertUnixToDateTime(DataUnixTime);
        [JsonProperty("main")]
        public DataTemperatureDomain Temperature { get; set; }

        private DateTime _ConvertUnixToDateTime(double unixTime)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return dt.AddSeconds(unixTime).ToLocalTime();
        }
    }
}
