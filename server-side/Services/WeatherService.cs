using System.Text.Json;
using Grpc.Core;
using server_side.Contracts;

namespace server_side.Services;

public class WeatherService : WheatherService.WheatherServiceBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public override async Task<WeatherResponse> GetCurrentWeather(
        GetCurrentWeatherRequest request, 
        ServerCallContext context)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var responseText = await httpClient.GetStringAsync(
            $"https://api.openweathermap.org/data/2.5/weather?q={request.City}&appid=c0619979f88b002e248e184a2e3f12ca&units={request.Unit}");
        
        var temperatures = JsonSerializer.Deserialize<Temperatures>(responseText);
        return new WeatherResponse {
            Temperature = temperatures!.Main.Temp,
            FeelsLike = temperatures.Main.FeelsLike
        };
    }
}