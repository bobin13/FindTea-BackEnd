using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace FindTeaBackEnd.Models
{
    public class Store
    {
        public ObjectId _id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string rating { get; set; }

        public Store(string name, string address, string city, string rating = "0")
        {
            this.name = name;
            this.address = address;
            this.city = city;
            this.rating = rating;
        }
    }
}