using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FindTeaBackEnd.Models
{
    public class Store
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string address_hint { get; set; }
        public double rating { get; set; }
        public string store_name { get; set; }
        public string thumbnailURL { get; set; }
        public List<Drink> drinks { get; set; }

    }
}