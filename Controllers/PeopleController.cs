using Microsoft.AspNetCore.Mvc;

namespace TestingOpenAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
     static string jokes = "https://swapi.dev/api/people/";
     private string? result;

     //GET api/values
      [HttpGet(Name = "GetPeople")]
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
