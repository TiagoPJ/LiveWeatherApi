using Domain.Enums;
using Domain.Helpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class FilterWeatherForecast
    {
        public IEnumerable<string> Cities { get; set; }
        public DateTime DtInitial { get; set; }
        public DateTime DtFinal { get; set; }
        public char Unit { get; set; }

        [JsonIgnore]
        public string UnitText => StringValueAttribute.GetEnumNameByStringValue<EnumUnits>(Unit.ToString());

        [JsonIgnore]
        public bool HasCities => Cities.Any();

        [JsonIgnore]
        public bool IsValidInitialDate => this.CheckDate(DtInitial.ToString());

        [JsonIgnore]
        public bool IsValidFinalDate => this.CheckDate(DtFinal.ToString());

        protected bool CheckDate(string date)
        {
            try
            {
                DateTime dt = DateTime.Parse(date);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
