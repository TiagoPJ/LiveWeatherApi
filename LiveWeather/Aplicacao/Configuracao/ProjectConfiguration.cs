using Domain.Forecast;
using System.Collections;
using System.Collections.Generic;

namespace Application.Configuracao
{
    public class ProjectConfiguration
    {
        public string UrlOpenWather { get; set; }
        public string Forecast { get; set; }
        public string Weather { get; set; }
        public string Key { get; set; }
        public string Unit { get; set; }
        public IEnumerable<CityDomain> CitiesDefault { get; set; }
    }
}
