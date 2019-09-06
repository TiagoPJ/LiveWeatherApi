using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Forecast
{
    public class DataTemperatureDto
    {
        public double Temp { get; set; }
        public double Pressure { get; set; }
        public int Humidity { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
    }
}
