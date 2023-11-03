using Blog.NETMVC.Models;
using Blog.NETMVC.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
namespace Blog.NETMVC.Controllers
{
    public class SpaceXController : Controller
    {
        string Baseurl = "https://api.spacexdata.com/v3/";


        [Route("spaceX/{offset?}/{limit?}")]
        [HttpGet]
        public async Task<IActionResult> Index(int? offset = null, int? limit = null)
        {
            // Retrieve the values from the query parameters
            ViewBag.Limit = limit;
            ViewBag.Offset = offset;

            List<Mission> Missions = new List<Mission>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = await client.GetAsync($"missions?offset={offset}&limit={limit}");
                if (Res.IsSuccessStatusCode)
                {
                    var response = Res.Content.ReadAsStringAsync().Result;
                    Missions = JsonConvert.DeserializeObject<List<Mission>>(response);

                    return View(Missions);
                }
                else
                {
                    return NotFound();
                }
                
            }
        }


        
    }
}
        