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
        public string store_name { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string address_hint { get; set; }
        public float rating { get; set; }

        public string thumbnailURL { get; set; }
        public List<Drink> drinks { get; set; }

    }
}