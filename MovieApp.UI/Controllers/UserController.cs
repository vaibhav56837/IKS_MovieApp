using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using MovieApp.Entity;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

namespace MovieApp.UI.Controllers
{
    public class UserController : Controller
    {
        IConfiguration _configuration;
        // IConfiguartion is an interface which use to aceess the key-value  throup app.settings and in case of
        // web-api project these process is not  under controller but inside the stratup.cs 
      
        public UserController (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public async Task<IActionResult> ShowUserDetails()
        {
            // Fetch API , Axios API ,HTTPClient 
            // HTTP Req/Response 
            // http verbs :HTTPGET HTTPPOST.....
            using (HttpClient client =new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "User/SelectUsers"; 
                using (var response =await client.GetAsync(endpoint))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result=await response.Content.ReadAsStringAsync();
                        // var userModels = Newtonsoft.Json.JsonSerializer.Deserialize<List<UserModel>>(result);
                        var userModels = JsonConvert.DeserializeObject<IEnumerable<UserModel>>(result);
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

        public  IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserModel userInfo)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content =  new StringContent(JsonConvert.SerializeObject(userInfo), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiURL"] + "User/Register";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "Register successfully!";
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

        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserModel userModel)
        {
            using(HttpClient client =new HttpClient())
            {
                StringContent content =new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "User/Login";
                using(var response= await client.PostAsync(endpoint, content))
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return RedirectToAction("ShowMovieDetails", "Movie");
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
        
        public async Task <IActionResult> UpdateUserDetails(int UserId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "User/GetSpecificUsers?UserId="+UserId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        // var userModels = Newtonsoft.Json.JsonSerializer.Deserialize<List<UserModel>>(result);
                        var userModels = JsonConvert.DeserializeObject<UserModel>(result);
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
        public async Task<IActionResult> UpdateUserDetails(UserModel userModel)
        {
            using(HttpClient client =new HttpClient())
            {
                StringContent constent=new StringContent(JsonConvert.SerializeObject(userModel), Encoding.UTF8, "application/json");
                string endpoint = _configuration["WebApiURL"] + "User/UpdateUser";
                using(var response=await client.PutAsync(endpoint, constent))
                {
                    if(response.StatusCode==System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "User-Field-Updated-Successfuly";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Invalid input ";
                    }
                }
            }
            return View();
        }

        public async Task<IActionResult> DeleteUserDetails(int UserId)
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = _configuration["WebApiURL"] + "User/GetSpecificUsers?UserId=" + UserId;
                using (var response = await client.GetAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        // var userModels = Newtonsoft.Json.JsonSerializer.Deserialize<List<UserModel>>(result);
                        var userModels = JsonConvert.DeserializeObject<UserModel>(result);
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
        public async Task<IActionResult> DeleteUserDetails(UserModel userModel)
        {
            using (HttpClient client = new HttpClient())
            {
       
                string endpoint = _configuration["WebApiURL"] + "User/DeleteUser?UserId="+userModel.UserId;
                using (var response = await client.DeleteAsync(endpoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Success";
                        ViewBag.message = "User-Deleted-Successfuly";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Invalid input ";
                    }
                }
            }
            return View();
        }
    }
}
