using FindTeaBackEnd.Handlers;
using FindTeaBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FindTeaBackEnd.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class StoresController : ControllerBase
    {
        DB db = new();

        [HttpGet("{cityQuery}")]
        public async Task<IActionResult> GetStoresByCity(string cityQuery)
        {

            if (cityQuery == null)
                return BadRequest("Error occured while trying to find this city! " + cityQuery);

            var filter = Builders<Store>.Filter.Eq("city", cityQuery);
            var stores = await db.GetCollection<Store>("stores").Find(filter).ToListAsync();

            return Ok(stores);
        }


        [HttpGet("id/{id}")]
        public IActionResult GetStoreById([FromBody] ObjectId id)
        {
            // string salt = Encrypt.GenerateSalt(13);
            // string hash = Encrypt.GenerateHash(salt, "bobin1314ist");
            // Boolean b = Encrypt.CheckHash(salt + "bobin1314ist", hash);
            // return Ok(b);
            // if (id == 0)
            //     return NotFound("No Store Found!");

            var filter = Builders<Store>.Filter.Eq("_id", id);
            var store = db.GetCollection<Store>("stores").Find(filter).FirstOrDefault();

            return Ok(store);
        }

        [HttpPost]
        public async Task<IActionResult> AddStore([FromBody] StoreDTO storeDTO)
        {
            Console.WriteLine("Store Add Request recieved!!");
            var store = db.GetCollection<Store>("stores");
            return Ok(store);
        }





    }
}