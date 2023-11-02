using Blog.NETMVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

[Route("api/spaceX")]
[ApiController]
public class SpaceXController : Controller
{

    [HttpGet]
    public async Task<IActionResult> Add()  // http://localhost:xxxx/AdminTags/Add: To view the Add page
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, "https://api.spacexdata.com/v3/missions");
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        Console.WriteLine(await response.Content.ReadAsStringAsync());

        var jsonContent = await response.Content.ReadAsStringAsync();

        return Ok(jsonContent);
    }

    



}
