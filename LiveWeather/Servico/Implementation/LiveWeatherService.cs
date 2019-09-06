using Application;
using Application.Configuracao;
using Application.Configuracao.Interfaces;
using Domain.Forecast;
using Newtonsoft.Json;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;

namespace Service.Implementation
{
    public class LiveWeatherService : ILiveWeatherService
    {
        private readonly IMessages _msgs;
        private ProjectConfiguration _projectConfiguration;

        public LiveWeatherService(ProjectConfiguration projectConfiguration, IMessages msgs)
        {
            _msgs = msgs;
            _projectConfiguration = projectConfiguration;
        }

        public IEnumerable<WeatherForecastDomain> GetWeatherForecast(FilterWeatherForecast filter)
        {
            try
            {
                if (!filter.HasCities)
                    _msgs.ErrorList.Add("City is required.");
                if (!filter.IsValidInitialDate)
                    _msgs.ErrorList.Add("Initial date is invalid.");
                if (!filter.IsValidFinalDate)
                    _msgs.ErrorList.Add("Initial date is invalid.");

                if (!_msgs.ExistError)
                {

                    var weatherForecastReturn = new List<WeatherForecastDomain>();
                    var weatherForecast = new WeatherForecastDomain();

                    foreach (var city in filter.Cities)
                    {
                        weatherForecast = this.ReturnObject<WeatherForecastDomain>(city, _projectConfiguration.Forecast, "POST", filter.UnitText);
                        //Apply filter date
                        weatherForecast.ForecastList = weatherForecast.ForecastList.Where(x => x.Date >= filter.DtInitial.Date && x.Date <= filter.DtFinal.Date);

                        weatherForecast.ForecastCurrent = this.ReturnObject<ForecastDomain>(city, _projectConfiguration.Weather, "GET", filter.UnitText);
                        weatherForecastReturn.Add(weatherForecast);
                    }

                    return weatherForecastReturn;
                }
            }
            catch (Exception ex)
            {
                _msgs.ErrorList.Add(string.Format("Has error: {0} ", ex.Message));
            }

            return null;
        }

        public IEnumerable<CityDomain> GetCitiesDefault()
        {
            return _projectConfiguration.CitiesDefault;
        }

        private T ReturnObject<T>(string city, string returnPath, string type, string unit)
        {
            var buildUrl = string.Concat(_projectConfiguration.UrlOpenWather,
                            string.Format(returnPath, city),
                            string.Format(_projectConfiguration.Unit, unit),
                            _projectConfiguration.Key);

            var requisicaoWeb = WebRequest.CreateHttp(buildUrl);
            requisicaoWeb.Method = type;

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(objResponse.ToString());
            }
        }
    }
}
