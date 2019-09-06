using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Forecast
{
    public class WeatherForecastDto
    {
        public int Count { get; set; }
        public IEnumerable<ForecastDto> ForecastList { get; set; }
        public CityDto City { get; set; }
        public ForecastDto ForecastCurrent { get; set; }
    }
}
