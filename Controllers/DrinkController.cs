using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeaBackEnd.Database;
using FindTeaBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FindTeaBackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinkController : ControllerBase
    {
        AppDb db = new();

        [HttpPost]
        public async Task<IActionResult> AddDrinkToStore([FromBody] DrinkDTO drinkDto)
        {
            if (drinkDto == null)
                return BadRequest("Error In drink Object");


            Drink drink = new Drink
            {
                store_id = drinkDto.store_id,
                drink_name = drinkDto.drink_name,
                is_hot_drink = drinkDto.is_hot_drink,
                drink_rating = drinkDto.drink_rating,
                is_registered = drinkDto.is_registered

            };
            await db.Drinks.AddAsync(drink);
            await db.SaveChangesAsync();

            return Ok(drink);
        }

        [HttpGet("drinks")]
        public IActionResult GetDrinksByStore([FromQuery] int id)
        {
            var drinks = db.Drinks.Where(e => e.id == id);

            return Ok(drinks);
        }
    }
}