using lilo.Models;
using lilo.Models.Errors;
using Microsoft.AspNetCore.Mvc;

namespace lilo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VideogamesController : ControllerBase
    {
        //[HttpGet("{id}")]
        //public Videogame? GetVideogameById(int id)
        //{
        //    Videogame? vgToReturn = null;
        //    foreach (Videogame v in FakieDB.videogames)
        //    {
        //        if (v.Id == id)
        //        {
        //            vgToReturn = v;
        //            break;
        //        }
        //    }

        //    return vgToReturn;
        //}

        [HttpGet("{id}")]
        public IActionResult GetVideogameById(int id)
        {
            Videogame? vgToReturn = null;
            foreach (Videogame v in FakieDB.videogames)
            {
                if (v.Id == id)
                {
                    vgToReturn = v;
                    break;
                }
            }
            if(vgToReturn is null)
                return NotFound(new CustomError()
                { StatusCode = "404",
                 Message = "Videogame not found :(" });

            return Ok(vgToReturn);
        }
    }
}
