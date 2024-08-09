using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindTeaBackEnd.Models
{
    public class Rating
    {
        public int id { get; set; }
        public int store_id { get; set; }
        public int drink_id { get; set; }
        public float drink_rating { get; set; }
    }
}