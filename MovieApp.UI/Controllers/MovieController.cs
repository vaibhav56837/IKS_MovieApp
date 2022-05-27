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
    public class MovieController : Controller
    {
        IConfiguration _configuration;

        public MovieController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public  async Task<IActionResult> ShowMovieDetails()
        {
            using(HttpClient client= new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Movie/SelectMovie";
                using(var response= await client.GetAsync(endpoint))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result=await response.Content.ReadAsStringAsync();
                        var movieModels= JsonConvert.DeserializeObject<IEnumerable<MovieModel>>(result);
                        return View(movieModels);
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

        public IActionResult RegisterMovie()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterMovie(MovieModel movieModel)
        {
            using(HttpClient client=new HttpClient())
            {
                StringContent constent = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endpoint= _configuration["WebApiURL"] + "Movie/Register";
                using (var response = await client.PostAsync(endpoint, constent))
                {
                    if(response.StatusCode ==System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Movie Added Successfuly!!";
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
       public async Task<IActionResult> UpdataeMovieDetails(int MovieId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Movie/GetSpecificMovie?id="+ MovieId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModels = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(movieModels);
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
        public async Task<IActionResult> UpdataeMovieDetails(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {
                StringContent constent = new StringContent(JsonConvert.SerializeObject(movieModel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "Movie/UpdateMovie";
                using (var response = await client.PutAsync(endpoint, constent))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Movie-Updated-Successfuly!!";
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

        public async Task<IActionResult>DeleteMovieDetails(int MovieId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "Movie/GetSpecificMovie?id=" + MovieId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModels = JsonConvert.DeserializeObject<MovieModel>(result);
                        return View(movieModels);
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
        public async Task<IActionResult> DeleteMovieDetails(MovieModel movieModel)
        {
            using (HttpClient client = new HttpClient())
            {
               
                string endpoint = _configuration["WebApiURL"] + "Movie/DeleteMovie?movieId="+movieModel.MovieId;
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Movie-Deleted-Successfuly!!";
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
