using CoreProfiler;
using CoreProfiler.Web;
using CoreProfilerSample.Repository;
using CoreProfilerSample.Service;
using CoreProfilerSample.Web.LogStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<IApiRepository, ApiRepository>();
services.AddScoped<IWeatherService, WeatherService>();
var app = builder.Build();

ProfilingSession.ProfilingStorage = new CoreProfilingStorage(app.Services.GetRequiredService<ILogger<CoreProfilingStorage>>());
//Coreprofiler
app.UseCoreProfiler(true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();