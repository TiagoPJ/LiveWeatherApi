using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Forecast
{
    public class DataTemperatureDomain
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        [JsonProperty("temp_min")]
        public double TemperatureMin { get; set; }
        [JsonProperty("temp_max")]
        public double TemperatureMax { get; set; }
    }
}
