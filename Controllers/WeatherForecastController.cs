using Microsoft.AspNetCore.Mvc;

namespace TestingOpenAPI.Controllers;

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
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

   /* static string jokes = "https://api.chucknorris.io/jokes/categories";
     private string? result;

     //GET api/values
      [HttpGet(Name = "GetJokes")]
     public async Task<IEnumerable<string>> GetAsync(){
        var result = await GetResponse();
        return new string[] {result,"value2"};
     }

     private async Task<string> GetResponse(){
        var client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(jokes);
       
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();

        return result;
     }*/
}
