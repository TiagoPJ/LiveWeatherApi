using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Application.Forecast
{
    public class ForecastDto
    {
        public IEnumerable<WeatherDto> Weather { get; set; }
        public DateTime Date { get; set; }
        public DataTemperatureDto Temperature { get; set; }
    }
}
