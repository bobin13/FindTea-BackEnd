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
    public class UserController : ControllerBase
    {
        DB dB = new DB();
        // string salt = Encrypt.GenerateSalt(13);
        // string hash = Encrypt.GenerateHash(salt, "bobin1314ist");
        // Boolean b = Encrypt.CheckHash(salt + "bobin1314ist", hash);
        // return Ok(b);



        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {

            try
            {
                if (user == null)
                    throw new ArgumentNullException("user");

                dB.GetCollection<User>("users").InsertOneAsync(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest("Error Occured While Adding User!");
            }
        }
    }
}