using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeaBackEnd.Models
{
    public class DrinkDTO
    {
        public int store_id { get; set; }
        public string drink_name { get; set; }
        public bool is_hot_drink { get; set; }
        public float drink_rating { get; set; }
        public bool is_registered { get; set; }

    }
}