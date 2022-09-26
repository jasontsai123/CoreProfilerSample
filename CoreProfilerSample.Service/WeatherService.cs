using CoreProfiler;
using CoreProfilerSample.Repository;

namespace CoreProfilerSample.Service;

public class WeatherService : IWeatherService
{
    private readonly IApiRepository _apiRepository;

    public WeatherService(IApiRepository apiRepository)
    {
        _apiRepository = apiRepository;
    }

    public IEnumerable<WeatherForecastDto> Get()
    {
        using var _ = ProfilingSession.Current.Step($"{typeof(WeatherService).Name}.{nameof(Get)}");
        return _apiRepository.GetWeather().Select(x => new WeatherForecastDto
        {
            Date = x.Date,
            TemperatureC = x.TemperatureC,
            Summary = x.Summary
        });
    }

    public async Task<IEnumerable<WeatherForecastDto>> GetAsync()
    {
        using var _ = ProfilingSession.Current.Step($"{typeof(WeatherService).Name}.{nameof(GetAsync)}");
        return (await _apiRepository.GetWeatherAsync()).Select(x => new WeatherForecastDto
        {
            Date = x.Date,
            TemperatureC = x.TemperatureC,
            Summary = x.Summary
        });
    }
}