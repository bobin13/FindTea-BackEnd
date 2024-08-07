using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FindTeaBackEnd.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public required string id { get; set; }

        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string salt { get; set; }

        public List<Store> favourites { get; set; }

    }
}