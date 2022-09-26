namespace CoreProfilerSample.Repository;

public interface IApiRepository
{
    IEnumerable<WeatherForecastDataModel> GetWeather();
    Task<IEnumerable<WeatherForecastDataModel>> GetWeatherAsync();
}