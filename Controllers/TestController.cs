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
            // string salt = Encrypt.GenerateSalt(13);
            // string hash = Encrypt.GenerateHash(salt, "bobin1314ist");
            // Boolean b = Encrypt.CheckHash(salt + "bobin1314ist", hash);
            // return Ok(b);
            Console.WriteLine(cityQuery);
            DbSQL db = new();
            string temp = db.GetStoresByCity(cityQuery);
            return Ok(temp);
        }


    }
}