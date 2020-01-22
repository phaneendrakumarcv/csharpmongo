using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace MongoDBApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData();
        }

        public static void MongoDBList()
        {
            MongoClient dbclient = new MongoClient("mongodb://127.0.0.1:27017");
            var dblist = dbclient.ListDatabases().ToList();
            foreach(var db in dblist)
            {
                Console.WriteLine(db.ToString());
            }
        }

        public static void InsertData()
        {
            MongoClient dbclient = new MongoClient("mongodb://127.0.0.1:27017");
            IMongoDatabase db = dbclient.GetDatabase("shop");
            BsonDocument item = new BsonDocument();
            item.Add(new BsonElement("name","Apple"));
            item.Add(new BsonElement("price", 100000));
            var items = db.GetCollection<BsonDocument>("products");
            items.InsertOne(item);
        }

        public static void GetData()
        {
            MongoClient dbclient = new MongoClient("mongodb://127.0.0.1:27017");
            IMongoDatabase db = dbclient.GetDatabase("shop");
            BsonDocument item = new BsonDocument();
            var items = db.GetCollection<BsonDocument>("products");
            var results = items.Find(new BsonDocument()).ToList();
            foreach(var shopitem in results)
            {
                Console.WriteLine(shopitem[1]);
            }
           
        }
    }
}
