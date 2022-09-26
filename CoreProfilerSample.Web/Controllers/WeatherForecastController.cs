using CoreProfilerSample.Service;
using Microsoft.AspNetCore.Mvc;

namespace CoreProfilerSample.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet("GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherService.Get().Select(x => new WeatherForecast
                {
                    Date = x.Date,
                    TemperatureC = x.TemperatureC,
                    Summary = x.Summary
                })
                .ToArray();
        }

        [HttpGet("AsyncWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> GetWeatherAsync()
        {
            return (await _weatherService.GetAsync()).Select(x => new WeatherForecast
                {
                    Date = x.Date,
                    TemperatureC = x.TemperatureC,
                    Summary = x.Summary
                })
                .ToArray();
        }
    }
}