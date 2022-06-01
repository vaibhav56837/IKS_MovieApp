using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieShowTimeController : ControllerBase
    {
        MovieShowTimeService _movieShowTimeService;
        public MovieShowTimeController(MovieShowTimeService movieShowTimeService)
        {
            _movieShowTimeService = movieShowTimeService;
        }
        [HttpGet("SelectMovieShowTime")]
        public  IActionResult SelectMovieShowTime()
        {
            return Ok(_movieShowTimeService.ShowMovieTimeList());
        }
        [HttpPost("InsertMovieShowTime")]
        public IActionResult InsertMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            return Ok(_movieShowTimeService.InsertMovieShowTime(movieShowTimeModel));
        }

        [HttpGet("GetSpecificMovieShowTime")]
        public IActionResult GetSpecificMovieShowTime(int id)
        {
            return Ok(_movieShowTimeService.GetSpecificMovieShowTimeById(id));
        }

        [HttpPut("UpdateMovieShowTime")]
        public IActionResult UpdateMovieShowTime(MovieShowTimeModel movieShowTimeModel)
        {
            return Ok(_movieShowTimeService.UpdateMovieShowTime(movieShowTimeModel));
        }

        [HttpDelete("DeleteMovieShowTime")]
        public IActionResult DeleteMovieShowTime(int id)
        {
            return Ok(_movieShowTimeService.DeleteMovieShowTime(id));
        }

        [HttpGet("GetShowTimesAndDateForSpecificTheatreAndMovie")]
        public IActionResult GetShowTimesAndDateForSpecificTheatreAndMovie(int mId)
        {
            return Ok(_movieShowTimeService.GetShowTimesAndDateForSpecificTheatreAndMovie(mId));
        }
    }
}
