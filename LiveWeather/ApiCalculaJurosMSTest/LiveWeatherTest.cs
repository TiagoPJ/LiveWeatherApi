using Api.Controllers;
using Application;
using Application.Configuracao;
using Application.Configuracao.Interfaces;
using Domain.Forecast;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveWeatherApiMSTest
{
    [TestClass]
    public class LiveWeatherTest
    {
        private readonly LiveWeatherController _calculoController;
        private readonly LiveWeatherService _liveWeatherService;
        private readonly IMessages _msgs;
        private ProjectConfiguration _projectConfiguration => ReturnProjectConfiguration();

        public LiveWeatherTest()
        {
            AdapterDtoDomain.MapperRegister();
            _msgs = new Messages();
            _liveWeatherService = new LiveWeatherService(_projectConfiguration, _msgs);
            _calculoController = new LiveWeatherController(_liveWeatherService, _msgs);
        }

        [TestMethod]
        public void GetCitiesTest_returnOkTrue()
        {
            var result = _calculoController.GetCitiesDefault();

            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        public void GetCitiesTest_returnOneOrMoreCity()
        {
            var result = _calculoController.GetCitiesDefault();
            Assert.IsTrue(result.Return.Any());
        }

        [TestMethod]
        [DataRow(3452925)]
        public void GetCitiesTest_returnCity(int idCity)
        {
            var result = _calculoController.GetCitiesDefault();
            Assert.IsTrue(result.Return.Where(x => x.Id.Equals(idCity)).Any());
        }

        [TestMethod]
        [DataRow("Porto Alegre", "06/09/2019", "07/09/2019", 'C')]
        [DataRow("Curitiba", "06/09/2019", "07/09/2019", 'F')]
        public void GetWeatherForecasTest_returnOkTrue(string city, string dtInitial, string dtFinal, char unit)
        {
            FilterWeatherForecast filter = FilterSearch(city, dtInitial, dtFinal, unit);

            var result = _calculoController.GetWeatherForecast(filter);
            Assert.IsTrue(result.IsOk);
        }

        [TestMethod]
        [DataRow("Teste Cidade", "06/09/2019", "07/09/2019", 'C')]
        [DataRow("Testando", "06/09/2019", "07/09/2019", 'F')]
        public void GetWeatherForecasTest_returnErroSearch(string city, string dtInitial, string dtFinal, char unit)
        {
            FilterWeatherForecast filter = FilterSearch(city, dtInitial, dtFinal, unit);

            var result = _calculoController.GetWeatherForecast(filter);
            Assert.IsFalse(result.IsOk);
        }

        private static FilterWeatherForecast FilterSearch(string city, string dtInitial, string dtFinal, char unit)
        {
            var dtFinalArray = dtFinal.Split('/').Select(x => int.Parse(x)).ToArray();
            var dtInitialArray = dtInitial.Split('/').Select(x => int.Parse(x)).ToArray();

            var filter = new FilterWeatherForecast()
            {
                Cities = new string[] { city },
                Unit = unit,
                DtFinal = new DateTime(dtFinalArray[2], dtFinalArray[1], dtFinalArray[0]),
                DtInitial = new DateTime(dtInitialArray[2], dtInitialArray[1], dtInitialArray[0])
            };
            return filter;
        }

        private static ProjectConfiguration ReturnProjectConfiguration()
        {
            return new ProjectConfiguration()
            {
                CitiesDefault = new List<CityDomain>() { new CityDomain() { Id = 3452925, Name = "Porto Alegre" } },
                UrlOpenWather = "https://api.openweathermap.org/data/2.5/",
                Weather = "weather?q={0}",
                Forecast = "forecast?q={0}",
                Unit = "&units={0}",
                Key = "&appid=8c3c1e1ba09566b3e40513ad6a3f0ed4"
            };
        }
    }
}
