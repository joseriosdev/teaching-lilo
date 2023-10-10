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
            Videogame? vgToReturn = FakieDB.videogames.FirstOrDefault(v => v.Id == id);
            //foreach (Videogame v in FakieDB.videogames)
            //{
            //    if (v.Id == id)
            //    {
            //        vgToReturn = v;
            //        break;
            //    }
            //}
            if(vgToReturn is null)
                return NotFound(new CustomError()
                { 
                    StatusCode = "404",
                    Message = "Videogame not found :("
                });

            return Ok(vgToReturn);
        }

        [HttpGet]
        public IActionResult GetAllVideogames() => Ok(FakieDB.videogames);

        [HttpPost]
        public IActionResult PostSingleVideogame([FromQuery] string name)
        {
            if(name is not null)
            {
                Videogame vgToInsert = new Videogame()
                {
                    Name = name,
                    Id = FakieDB.videogames.Count() + 1
                };

                FakieDB.videogames.Add(vgToInsert);
                return Ok(vgToInsert);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
