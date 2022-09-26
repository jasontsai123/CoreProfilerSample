using CoreProfiler;

namespace CoreProfilerSample.Repository;

public class ApiRepository : IApiRepository
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public ApiRepository()
    {
    }

    public IEnumerable<WeatherForecastDataModel> GetWeather()
    {
        using var _ = ProfilingSession.Current.Step($"{typeof(ApiRepository).Name}.{nameof(GetWeather)}");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastDataModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    public async Task<IEnumerable<WeatherForecastDataModel>> GetWeatherAsync()
    {
        using var _ = ProfilingSession.Current.Step($"{typeof(ApiRepository).Name}.{nameof(GetWeatherAsync)}");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastDataModel
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}