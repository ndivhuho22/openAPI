using Microsoft.AspNetCore.Mvc;

namespace TestingOpenAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class JokesController : ControllerBase
{
     static string jokes = "https://api.chucknorris.io/jokes/categories";
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
     }
}
