using Application.Forecast;
using AutoMapper;
using Domain.Forecast;

namespace Application
{
    public class AdapterDtoDomain
    {
        private static object _thisLock = new object();
        private static bool _initialized = false;

        public AdapterDtoDomain()
        {
        }

        public static void MapperRegister()
        {
            // This will ensure one thread can access to this static initialize call
            // and ensure the mapper is reseted before initialized
            lock (_thisLock)
            {
                if (!_initialized)
                {
                    Mapper.Initialize(cfg =>
                    {
                        cfg.CreateMap<ForecastDto, ForecastDomain>()
                        .ForMember(dom => dom.DataUnixTime, opt => opt.Ignore()).ReverseMap();
                        cfg.CreateMap<WeatherDto, WeatherDomain>().ReverseMap();
                    });

                    _initialized = true;
                }
            }           
        }
    }
}
