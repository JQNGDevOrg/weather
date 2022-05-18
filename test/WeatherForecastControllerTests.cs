using FluentAssertions;
using weather.Controllers;
using NSubstitute;
using Microsoft.Extensions.Logging;

namespace test;

public class WeatherForecastControllerTests
{
    [Fact]
    public void ShouldReturnARangeOfForecasts()
    {
        var controller = new WeatherForecastController(Substitute.For<ILogger<WeatherForecastController>>());

        var result = controller.Get();

        result.Count().Should().BeInRange(1, 5);
        foreach (var forecast in result)
        {
            forecast.Date.Should().BeAfter(DateTime.Today);
            forecast.TemperatureC.Should().BeInRange(-20, 32);
            forecast.Summary.Should().NotBeNullOrEmpty();
        }
    }

    [Fact]
    public void ShouldReturnASingleForcast()
    {
        var controller = new WeatherForecastController(Substitute.For<ILogger<WeatherForecastController>>());

        var forecast = controller.Post(0);

        forecast.Date.Should().BeAfter(DateTime.Today);
        forecast.TemperatureC.Should().Be(0);
        forecast.TemperatureF.Should().Be(32);
        forecast.Summary.Should().NotBeNullOrEmpty();
    }
}