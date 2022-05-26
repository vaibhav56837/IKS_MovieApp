using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }
        [HttpGet("SelectMovie")]
        public IActionResult SelectMovie()
        {
            return Ok(_movieService.SelectMovies());
        }

        [HttpGet("GetSpecificMovie")]
        public IActionResult GetSpecificMovie(int id)
        {
            return Ok(_movieService.GetSpecificMovie(id));
        }


        [HttpPost("Register")]
        public IActionResult Register(MovieModel movieModel)
        {
            return Ok(_movieService.Register(movieModel));
        }

        [HttpPut("UpdateMovie")]
        public IActionResult UpdateMovie([FromBody] MovieModel movieModel)
        {
            return Ok(_movieService.UpdateMovie(movieModel));
        }
        [HttpDelete("DeleteMovie")]
        public IActionResult DeleteMovie(int movieId)
        {
            return Ok(_movieService.DeleteMovie(movieId));  
        }
        [HttpPatch]
        public IActionResult UpdateMovieDetails([FromBody] MovieModel movieModel)
        {
            return Ok(_movieService.UpdateMovieDetails(movieModel));
        }
    }
}
