using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Forecast
{
    public class WeatherForecastDomain
    {
        [JsonProperty("cnt")]
        public int Count { get; set; }
        [JsonProperty("list")]
        public IEnumerable<ForecastDomain> ForecastList { get; set; }
        public CityDomain City { get; set; }
        public ForecastDomain ForecastCurrent { get; set; }
    }
}
