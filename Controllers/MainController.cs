using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeaBackEnd.Handlers;
using FindTeaBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindTeaBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainController : ControllerBase
    {
        DBHandler db = new DBHandler();

        [HttpGet("find")]
        public IActionResult FindStoresByCity([FromQuery] string city)
        {
            if (city == null)
                return BadRequest("Enter a Valid City!!");

            var AllStoresInACity = db.GetStoresByCity("london");
            foreach (var store in AllStoresInACity)
            {
                Console.WriteLine(store.address);
            }
            return Ok(AllStoresInACity);
        }
    }
}