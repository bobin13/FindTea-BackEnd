using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeaBackEnd.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace FindTeaBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            string salt = Encrypt.GenerateSalt(13);
            string hash = Encrypt.GenerateHash("salty", "bobin1314ist");
            Boolean b = Encrypt.CheckHash("saltbobin1314ist", hash);
            return Ok(salt);
        }
    }
}