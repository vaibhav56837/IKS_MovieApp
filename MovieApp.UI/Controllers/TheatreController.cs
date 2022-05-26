using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MovieApp.Entity;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.UI.Controllers
{
    public class TheatreController : Controller
    {
        IConfiguration _configuration;

        public TheatreController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> ShowTheatreDetails()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Theatre/SelectTheatre";
                using(var response= await client.GetAsync(endpoint))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModels = JsonConvert.DeserializeObject<IEnumerable<TheatreModel>>(result);
                        return View(userModels);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries";
                    }
                }
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(TheatreModel theatreModel)
        {
            using(HttpClient client =new HttpClient())
            {
                StringContent constent = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "Theatre/Register";
                using(var response=await client.PostAsync(endpoint,constent))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Theatre Added Successfuly!!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong-Entries!!";
                    }
                }
            }
            return View();
        }
    }
}

