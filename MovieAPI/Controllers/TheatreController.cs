using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;
namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        TheatreService _theatreService;

         public TheatreController (TheatreService theatreService)
        {
            _theatreService = theatreService;   
        }

        [HttpPost("Register")]
        public IActionResult Register(TheatreModel theatreModel)
        {

            return Ok(_theatreService.Register(theatreModel));
        }
        [HttpGet("SelectTheatre")]
        public IActionResult SelectTheatre()
        {
            return Ok(_theatreService.SelectTheatre());
        }
        [HttpDelete("DeleteTheatre")]
        public IActionResult DeleteTheatre(int tId)
        {
            _theatreService.DeleteTheatre(tId);
            return Ok("Deleted");
        }

        [HttpPut("UpdateTheatre")]
        public IActionResult UpdateTheatre(TheatreModel theatreModel)
        {
            _theatreService.UpadateTheatre(theatreModel);
            return Ok("Updataed ");
        }

        [HttpGet("GetSpecificTheatre")]
        public TheatreModel GetSpecificTheatre(int tId)
        {
            return _theatreService.GetSpecificTheatre(tId);
        }
    }
}
