using FluentAssertions;
using weather;

namespace test;

public class WeatherForecastTests
{
    [Fact]
    public void GivenCelciusTempZero_FarenheitTemperatureShouldBe32()
    {
        var forecast = new WeatherForecast();

        forecast.TemperatureF.Should().Be(32);
    }
}