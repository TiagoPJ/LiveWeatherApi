using Application;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Application.Forecast;
using System.Collections.Generic;
using Application.Configuracao;
using System.Linq;
using Microsoft.Extensions.Options;
using Domain.Forecast;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Service.Implementation;
using Service.Interfaces;
using Application.Configuracao.Interfaces;

namespace APICalculaJurosXUnitTest
{
    public class LiveWeatherIntegrationTest
    {
        private readonly TestProvider _testProvider;
        public LiveWeatherIntegrationTest()
        {
            var porj = new ProjectConfiguration()
            {
                CitiesDefault = new List<CityDomain>() { new CityDomain() { Id = 3452925, Name = "Porto Alegre" } },
                UrlOpenWather = "https://api.openweathermap.org/data/2.5/",
                Weather = "weather?q={0}",
                Forecast = "forecast?q={0}",
                Unit = "&units={0}",
                Key = "&appid=8c3c1e1ba09566b3e40513ad6a3f0ed4"
            };

            _testProvider = new TestProvider();
             new LiveWeatherService(porj, new Messages());
            //var services = new ServiceCollection();

            //var settings = new ProjectConfiguration()
            //{
            //    CitiesDefault = new List<CityDomain>() { new CityDomain() { Id = 3452925, Name = "Porto Alegre" } },
            //    UrlOpenWather = "https://api.openweathermap.org/data/2.5/",
            //    Weather = "weather?q={0}",
            //    Forecast = "forecast?q={0}",
            //    Unit = "&units={0}",
            //    Key = "&appid=8c3c1e1ba09566b3e40513ad6a3f0ed4"
            //};

            //services.AddSingleton(
            //    provider => Options.Create(settings));
            //services.BuildServiceProvider();

            //var builder = new ConfigurationBuilder()
            //.AddJsonFile("appsettings.json", true, true)
            //.AddEnvironmentVariables();
            //var configurationRoot = builder.Build();
            //configurationRoot.GetSection("ProjectConfiguration").Bind(new ProjectConfiguration());
        }

        [Fact]
        //[Theory]
        //[InlineData("Porto Alegre", 'F')]
        //[InlineData("Curitiba", 'C')]
        public async Task GetWeatherForecast_Post_ReturnsOkResponse()
        {
            var jsonToPost = JsonConvert.SerializeObject(FilterSearch("Porto Alegre", 'C'));
            var stringContent = new StringContent(jsonToPost, Encoding.UTF8, "application/json");

            var response = await _testProvider.Client.PostAsync("/LiveWeather/GetWeatherForecast", stringContent);
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var jsonRetorno = await response.Content.ReadAsStringAsync();
            var objetoRetorno = JsonConvert.DeserializeObject<ResultApi<IEnumerable<WeatherForecastDto>>>(jsonRetorno);
            objetoRetorno.IsOk.Should().Be(true);
            objetoRetorno.Return.Any().Should().Be(true);

            _testProvider.Dispose();
        }

        //[Fact]
        //public async Task InformacoesProjeto_Get_ReturnsOkResponse()
        //{
        //    var settings = new ProjectConfiguration()
        //    {
        //        UrlProjeto = "https://github.com/",
        //        UrlIframeProjeto = "//cdn.iframe.ly"
        //    };

        //    IOptions<ProjectConfiguration> appSettingsOptions = Options.Create(settings);

        //    var response = await _testProvider.Client.GetAsync("/InformacoesProjeto/ObterInformacoesProjeto");
        //    response.EnsureSuccessStatusCode();
        //    response.StatusCode.Should().Be(HttpStatusCode.OK);

        //    _testProvider.Dispose();
        //}

        private void _BuildProjectConfiguration()
        {
            var settings = new ProjectConfiguration()
            {
                UrlOpenWather = "https://api.openweathermap.org/data/2.5/",
                Weather = "weather?q={0}",
                Forecast = "forecast?q={0}",
                Unit = "&units={0}",
                Key = "&appid=8c3c1e1ba09566b3e40513ad6a3f0ed4"
            };

            IOptions<ProjectConfiguration> appSettingsOptions = Options.Create(settings);
        }

        private static FilterWeatherForecast FilterSearch(string city, char unit)
        {
            var filter = new FilterWeatherForecast()
            {
                Cities = new string[] { city },
                Unit = unit,
                DtFinal = new DateTime().AddDays(1),
                DtInitial = new DateTime()
            };
            return filter;
        }

        private static ProjectConfiguration ReturnProjectConfiguration()
        {
            return new ProjectConfiguration()
            {
                UrlOpenWather = "https://api.openweathermap.org/data/2.5/",
                Weather = "weather?q={0}",
                Forecast = "forecast?q={0}",
                Unit = "&units={0}",
                Key = "&appid=8c3c1e1ba09566b3e40513ad6a3f0ed4"
            };
        }
    }
}