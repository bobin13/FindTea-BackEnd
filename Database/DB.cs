using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeaBackEnd.Models;
using MongoDB.Driver;

namespace FindTeaBackEnd.Handlers
{
    public class DB
    {
        MongoClient client = new MongoClient("mongodb+srv://bobin13:4K8J276bWqmd5iBr@cluster0.wi0uk9y.mongodb.net/?retryWrites=true&w=majority");
        string dbName = "tims_app";

        //returns a collectioin as a list whose name is passed.
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {

            var db = client.GetDatabase(dbName);
            return db.GetCollection<T>(collectionName);

        }
        public void GetAllStores()
        {
            var collection = GetCollection<Store>("stores");

        }

        public List<Store> GetStoresByCity(string city)
        {
            FilterDefinition<Store> filter = Builders<Store>.Filter.Eq("city", city);
            var collection = client.GetDatabase(dbName).GetCollection<Store>("stores");
            List<Store> result = collection.Find(filter).ToList();

            return result;
        }
        public bool AddStore(Store store)
        {
            if (store == null)
                return false;

            var collection = GetCollection<Store>("stores");
            if (collection == null)
                return false;

            collection.InsertOne(store);

            return true; //returns true if store added.
        }


    }
}