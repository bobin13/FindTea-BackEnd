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
    public class StoreController : ControllerBase
    {
        AppDb db = new();

        // [HttpGet("find")]
        // public IActionResult FindStoresByCity([FromQuery] string city)
        // {
        //     if (city == null)
        //         return BadRequest("Enter a Valid City!!");

        //     var AllStoresInACity = db.GetStoresByCity("london");
        //     foreach (var store in AllStoresInACity)
        //     {
        //         Console.WriteLine(store.address);
        //     }
        //     return Ok(AllStoresInACity);
        // }

        [HttpGet("find")]
        public IActionResult GetStoresByCity([FromQuery] string cityQuery)
        {
            // string salt = Encrypt.GenerateSalt(13);
            // string hash = Encrypt.GenerateHash(salt, "bobin1314ist");
            // Boolean b = Encrypt.CheckHash(salt + "bobin1314ist", hash);
            // return Ok(b);
            var stores = db.Stores.Where(e => e.city == cityQuery);
            return Ok(stores);
        }

        [HttpPost]
        public async Task<IActionResult> AddStore([FromBody] StoreDTO storeDTO)
        {
            Console.WriteLine("Store Add Request recieved!!");
            Store store = new Store
            {
                store_name = storeDTO.store_name,
                city = storeDTO.city,
                address = storeDTO.address,
                rating = storeDTO.rating
            };

            //Console.WriteLine($"{store.id} {store.store_name} {store.city} {store.address} {store.rating}");
            await db.Stores.AddAsync(store);
            await db.SaveChangesAsync();

            return Ok(store);
        }
    }
}