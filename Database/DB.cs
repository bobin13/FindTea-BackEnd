using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindTeaBackEnd.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using sheridan_connect_backend;

namespace FindTeaBackEnd.Handlers
{
    public class DB
    {
        string dbName = "tims_app";

        //returns a collectioin as a list whose name is passed.
        public string GetConnectionString()
        {
            var username = Environment.GetEnvironmentVariable("USERNAME");
            var password = Environment.GetEnvironmentVariable("PASSWORD");

            if (String.IsNullOrEmpty(username) && String.IsNullOrEmpty(password))
                throw new ArgumentException("Database Username/Password can't be null or empty!", nameof(username));

            var uri = $"mongodb+srv://{username}:{password}@cluster0.wi0uk9y.mongodb.net/";

            return uri;
        }

        public MongoClient GetMongoClient()
        {
            var client = new MongoClient(GetConnectionString());

            return client;

        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {

            var db = GetMongoClient().GetDatabase(dbName);
            return db.GetCollection<T>(collectionName);

        }


        public IMongoCollection<T> FilterCollection<T>(string collectionName, string property, string search)
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq(property, search);
            var collection = GetMongoClient().GetDatabase(dbName).GetCollection<T>(collectionName);
            IMongoCollection<T> result = (IMongoCollection<T>)collection.Find(filter);

            return result;
        }


    }
}