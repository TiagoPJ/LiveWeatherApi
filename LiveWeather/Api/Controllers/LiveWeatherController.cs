using Application;
using Application.Configuracao;
using Application.Configuracao.Interfaces;
using Application.Forecast;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("[controller]/[action]")]
    public class LiveWeatherController : BaseController
    {
        private readonly ILiveWeatherService _liveWeatherService;

        public LiveWeatherController(ILiveWeatherService liveWeatherService, IMessages msgs) : base(msgs)
            => _liveWeatherService = liveWeatherService;

        /// <summary>
        /// Returns Weather forecast.
        /// </summary>
        /// <param name="filter">Filter to search weather forecast</param>
        [HttpPost]
        public ResultApi<IEnumerable<WeatherForecastDto>> GetWeatherForecast([FromBody] FilterWeatherForecast filter)
        {
            var retorno = _liveWeatherService.GetWeatherForecast(filter);
            return FormatResult(Mapper.Map<IEnumerable<WeatherForecastDto>>(retorno));
        }

        /// <summary>
        /// Returns City(ies) default.
        /// </summary>
        [HttpGet]
        public ResultApi<IEnumerable<CityDto>> GetCitiesDefault()
        {
            var retorno = _liveWeatherService.GetCitiesDefault();
            return FormatResult(Mapper.Map<IEnumerable<CityDto>>(retorno));
        }
    }
}