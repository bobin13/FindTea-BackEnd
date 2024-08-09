using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FindTeaBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // string salt = Encrypt.GenerateSalt(13);
        // string hash = Encrypt.GenerateHash(salt, "bobin1314ist");
        // Boolean b = Encrypt.CheckHash(salt + "bobin1314ist", hash);
        // return Ok(b);
    }
}