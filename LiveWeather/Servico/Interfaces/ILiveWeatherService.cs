using Application;
using Domain.Forecast;
using System.Collections.Generic;

namespace Service.Interfaces
{
    public interface ILiveWeatherService
    {
        IEnumerable<WeatherForecastDomain> GetWeatherForecast(FilterWeatherForecast filter);
        IEnumerable<CityDomain> GetCitiesDefault();
    }
}
