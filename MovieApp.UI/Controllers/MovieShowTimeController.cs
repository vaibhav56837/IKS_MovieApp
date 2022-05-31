using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MovieApp.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace MovieApp.UI.Controllers
{
    public class MovieShowTimeController : Controller
    {
        IConfiguration _configuration;
        public MovieShowTimeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> ShowMovieTime()
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/SelectMovieShowTime";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimes = JsonConvert.DeserializeObject<List<MovieShowTimeModel>>(result);
                        return View(movieShowTimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> InsertMovieShowTimes()
        {
            
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Movie/SelectMovie";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieModel = JsonConvert.DeserializeObject<List<MovieModel>>(result);
                        List<SelectListItem> selectListItemsMovies = new List<SelectListItem>();
                        foreach (var item in movieModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.MovieName;
                            selectListItem.Value = item.MovieId.ToString();
                            selectListItemsMovies.Add(selectListItem);
                            ViewBag.movieData = selectListItemsMovies;
                        }
                    }
                }
            }
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "Theatre/SelectTheatre";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var theatreModel = JsonConvert.DeserializeObject<List<TheatreModel>>(result);
                        List<SelectListItem> selectListItemsTheatre = new List<SelectListItem>();
                        foreach (var item in theatreModel)
                        {
                            SelectListItem selectListItem = new SelectListItem();
                            selectListItem.Text = item.tName;
                            selectListItem.Value = item.tId.ToString();
                            selectListItemsTheatre.Add(selectListItem);
                            ViewBag.theatreData = selectListItemsTheatre;
                        }
                    }
                }
            }
           
            return View();
        }

        [HttpPost]

        // [ValidateAntiForgeryToken] [Bind("ShowId,MovieId,TheatreId,ShowTime,Date")]
        public async Task<IActionResult> InsertMovieShowTimes( MovieShowTimeModel movieShowTimeModel )
        {
            using(HttpClient client =new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTimeModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/InsertMovieShowTime";
                using(var response=await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "Inserted!";
                         return RedirectToAction("ShowMovieTime", "MovieShowTime");
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
           
            return View();
        }

        public async Task <IActionResult>UpdateMovieshowTimes(int ShowId)
        {
            using(HttpClient client =new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/GetSpecificMovieShowTime?id="+ShowId;
                using(var response= await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimes = JsonConvert.DeserializeObject<MovieShowTimeModel>(result);
                        return View(movieShowTimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovieshowTimes(MovieShowTimeModel movieShowTimeModel)
        {
            using(HttpClient client=new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movieShowTimeModel), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/UpdateMovieShowTime";
                using (var response = await client.PutAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "MovieShowTime-Updated-Successfuly!!";
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
        public async Task<IActionResult> DeleteMovieshowTimes(int ShowId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/GetSpecificMovieShowTime?id=" + ShowId;
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var movieShowTimes = JsonConvert.DeserializeObject<MovieShowTimeModel>(result);
                        return View(movieShowTimes);
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "No Data Found!";
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteMovieshowTimes(MovieShowTimeModel movieShowTimeModel)
        {
            using (HttpClient client = new HttpClient())
            {
                
                string endPoint = _configuration["WebApiURL"] + "MovieShowTime/DeleteMovieShowTime?id="+movieShowTimeModel.ShowId;
                using (var response = await client.DeleteAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "MovieShowTime-Updated-Successfuly!!";
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
