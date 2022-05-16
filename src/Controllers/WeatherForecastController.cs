using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

namespace weather.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = RandomNumberGenerator.GetInt32(-20, 32),
            Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpPost]
    [Route("{celcius:int}")]
    public WeatherForecast Post(int celcius)
    {
        _logger.LogDebug($"Number posted : {celcius}");

        return new WeatherForecast
        {
            Date = DateTime.Now,
            TemperatureC = celcius,
            Summary = Summaries[RandomNumberGenerator.GetInt32(Summaries.Length)]
        };
    }
}
