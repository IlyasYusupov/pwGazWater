using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.GridFS;
using DnsClient;

namespace pwGazWater.Data
{
    public static class Mongo
    {
        public static void AddToDB(User user)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            collection.InsertOne(user);
        }

        public static User Find(string name)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            var one = collection.Find(x => x.Login == name).FirstOrDefault();
            return one;
        }

        public static List<User> FindAll()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            var list = collection.Find(x => true).ToList();
            var users = new List<User>();
            foreach (var user in list)
            {
                users.Add(user);
            }
            return users;
        }

        public static void UpgradeOne(string login, string seting, string item)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            var update = Builders<User>.Update.Set(seting, item);
            collection.UpdateOne(x => x.Login == login, update);
        }
    }
}