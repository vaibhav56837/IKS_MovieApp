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
        public IActionResult RegisterTheatre()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterTheatre(TheatreModel theatreModel)
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
        
         public async Task<IActionResult>UpdateTheatreDetails(int tId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Theatre/GetSpecificTheatre?tId="+ tId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModels = JsonConvert.DeserializeObject<TheatreModel>(result);
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
        [HttpPost]
        public async Task<IActionResult> UpdateTheatreDetails(TheatreModel theatreModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent constent = new StringContent(JsonConvert.SerializeObject(theatreModel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "Theatre/UpdateTheatre";
                using (var response = await client.PutAsync(endpoint, constent))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Theatre-Data-Updated-Successfuly!!";
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
        public async Task<IActionResult> DeleteTheatreDetails(int tId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Theatre/GetSpecificTheatre?tId=" + tId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var userModels = JsonConvert.DeserializeObject<TheatreModel>(result);
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
        [HttpPost]
        public async Task<IActionResult> DeleteTheatreDetails(TheatreModel theatreModel)
        {
            using (HttpClient client = new HttpClient())
            {
       
                string endpoint = _configuration["WebApiURL"] + "Theatre/DeleteTheatre?tId="+theatreModel.tId;
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Theatre-Data-Deleted-Successfuly!!";
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

