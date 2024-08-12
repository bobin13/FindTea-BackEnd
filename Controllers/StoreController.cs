using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeaBackEnd.Database;
using FindTeaBackEnd.Handlers;
using FindTeaBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindTeaBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        AppDb db = new();

        [HttpGet("find")]
        public IActionResult GetStoresByCity([FromQuery] string cityQuery)
        {
            // string salt = Encrypt.GenerateSalt(13);
            // string hash = Encrypt.GenerateHash(salt, "bobin1314ist");
            // Boolean b = Encrypt.CheckHash(salt + "bobin1314ist", hash);
            // return Ok(b);
            if (cityQuery == null)
                return Ok(db.Stores.ToList());

            var stores = db.Stores.Where(e => e.city == cityQuery);
            return Ok(stores);
        }
        public List<Drink> GetDrinks(int store_id)
        {
            var allDrinks = db.Drinks.Where(e => e.store_id == store_id);
            var drinks = new List<Drink>();

            foreach (var drink in allDrinks)
            {

                drinks.Add(drink);
            }
            return drinks;

        }

        [HttpGet("id")]
        public IActionResult GetStoreById([FromQuery] int id)
        {
            // string salt = Encrypt.GenerateSalt(13);
            // string hash = Encrypt.GenerateHash(salt, "bobin1314ist");
            // Boolean b = Encrypt.CheckHash(salt + "bobin1314ist", hash);
            // return Ok(b);
            if (id == 0)
                return NotFound("No Store Found!");


            var store = db.Stores.FirstOrDefault(e => e.id == id);
            if (id != null)
                store.drinks = GetDrinks(id);


            return Ok(store);
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