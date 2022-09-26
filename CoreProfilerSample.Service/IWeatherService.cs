namespace CoreProfilerSample.Service;

public interface IWeatherService
{
    IEnumerable<WeatherForecastDto> Get();
    Task<IEnumerable<WeatherForecastDto>> GetAsync();
}