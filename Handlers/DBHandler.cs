using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeaBackEnd.Models;
using MongoDB.Driver;

namespace FindTeaBackEnd.Handlers
{
    public class DBHandler
    {
        MongoClient client = new MongoClient("mongodb+srv://bobin13:q42Qun2fCPPYbhjQ@cluster0.wi0uk9y.mongodb.net/?retryWrites=true&w=majority");

        public void GetAllStores()
        {
            var collection = GetStoresCollection();

        }

        public List<Store> GetStoresByCity(string city)
        {
            FilterDefinition<Store> filter = Builders<Store>.Filter.Eq("city", city);
            var collection = client.GetDatabase("tims_app").GetCollection<Store>("stores");
            List<Store> result = collection.Find(filter).ToList();

            return result;
        }
        public bool AddStore(Store store)
        {
            if (store == null)
                return false;

            var collection = GetStoresCollection();
            if (collection == null)
                return false;

            collection.InsertOne(store);

            return true; //returns true if store added.
        }
        public IMongoCollection<Store> GetStoresCollection()
        {
            var collection = client.GetDatabase("tims_app").GetCollection<Store>("stores");
            return collection;
        }

    }
}