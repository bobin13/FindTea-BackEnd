using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeaBackEnd.Database;
using FindTeaBackEnd.Handlers;
using FindTeaBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindTeaBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {

        readonly AppDb db = new();

        [HttpGet]
        public IActionResult GetStoresByCity(string cityQuery)
        {

            Console.WriteLine(cityQuery);
            DbSQL db = new();
            string temp = db.GetStoresByCity(cityQuery);
            return Ok(temp);
        }


    }
}