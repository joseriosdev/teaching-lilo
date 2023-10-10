using lilo.Models;
using lilo.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace lilo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoreController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] InsertStoreDTO store)
        {

            return Ok();
        }
    }
}