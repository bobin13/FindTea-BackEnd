using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FindTeaBackEnd.Models
{
    public class Store
    {
        public int id { get; set; }
        public string? store_name { get; set; }
        public string? city { get; set; }
        public string? address { get; set; }
        public float? rating { get; set; }

        public Store()
        {

        }
        public Store(int id, string store_name, string address, string city, float rating = 0)
        {
            this.id = id;
            this.store_name = store_name;
            this.city = city;
            this.address = address;
            this.rating = rating;
        }
    }
}