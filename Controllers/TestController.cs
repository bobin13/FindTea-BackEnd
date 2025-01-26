using FindTeaBackEnd.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace FindTeaBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {

        DB db = new();

        [HttpGet]
        public IActionResult GetStoresByCity(string cityQuery)
        {

            Console.WriteLine(cityQuery);

            return Ok();
        }


    }
}