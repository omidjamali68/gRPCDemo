using System.Text.Json;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using server_side.Contracts;

namespace server_side.Services;

public class WeatherService : WheatherService.WheatherServiceBase
{
    private const string ApiKey = "c0619979f88b002e248e184a2e3f12ca" ;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<WeatherService> _logger;

    public WeatherService(IHttpClientFactory httpClientFactory, ILogger<WeatherService> logger)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    public override async Task<WeatherResponse> GetCurrentWeather(
        GetCurrentWeatherRequest request, 
        ServerCallContext context)
    {        
        Temperatures? temperatures = await GetCurrentTemperatures(request);
        return new WeatherResponse
        {
            Temperature = temperatures!.Main.Temp,
            FeelsLike = temperatures.Main.FeelsLike,
            Timestamp = Timestamp.FromDateTime(DateTime.UtcNow)
        };
    }

    public override async Task GetCurrentWeatherStream(
        GetCurrentWeatherRequest request, 
        IServerStreamWriter<WeatherResponse> responseStream, 
        ServerCallContext context)
    {        
        for (int i = 0; i < 30; i++)
        {
            if (context.CancellationToken.IsCancellationRequested)
            {
                _logger.LogInformation("Request was cancelled by user");
                break;
            }

            Temperatures? temperatures = await GetCurrentTemperatures(request);
            await responseStream.WriteAsync(new WeatherResponse{
                Temperature = temperatures!.Main.Temp,
                FeelsLike = temperatures.Main.FeelsLike,
                Timestamp = Timestamp.FromDateTime(DateTime.UtcNow)
            });
            await Task.Delay(1000);
        }
    }

    private async Task<Temperatures?> GetCurrentTemperatures(GetCurrentWeatherRequest request)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var responseText = await httpClient.GetStringAsync(
                    $"https://api.openweathermap.org/data/2.5/weather?q={request.City}&appid={ApiKey}&units={request.Unit}");

        var temperatures = JsonSerializer.Deserialize<Temperatures>(responseText);
        return temperatures;
    }
}