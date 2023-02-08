using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.GridFS;
using pwGazWater.Data;

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

        public static User Find(string login)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            var one = collection.Find(x => x.Login == login).FirstOrDefault();
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
                users.Add(user);
            return users;
        }

        public static void Replace(string login, User user)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            collection.ReplaceOne(z => z.Login == login, user);
        }


        public static void UpgradeOne(string login, string seting, List<Project> item)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            var update = Builders<User>.Update.Set(seting, item);
            collection.UpdateOne(x => x.Login == login, update);
        }


        public static void AddToDBPlanner(PlannerDocument doc)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<PlannerDocument>("PlannerDocument");
            collection.InsertOne(doc);
        }

        public static void AddProjectToDB(Project project)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<Project>("project");
            collection.InsertOne(project);
        }

        public static Project FindProject(string name)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<Project>("project");
            var one = collection.Find(x => x.Name == name).FirstOrDefault();
            return one;
        }
        public static User FindCustomer(string login)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            var list = collection.Find(x => true).ToList();
            var users = new List<User>();
            foreach (var user in list)
            {
                if (user.GetType().Name == "Customer" && user.Login == login)
                    return user;
            }
            return null;
        }

        public static List<User> FindAllEmployee(string login)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            var list = collection.Find(x => true).ToList();
            var users = new List<User>();
            foreach (var user in list)
            {
                if (user.Login != login)
                    users.Add(user);
            }
            return users;
        }



        public static void ReplaceProject(string name, Project project)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<Project>("project");
            collection.ReplaceOne(z => z.Name == name, project);
        }

        public static List<Project> FindAllPlannerProject(string login)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<Project>("project");
            var list = collection.Find(x => x.Planner.Login == login).ToList();
            var projects = new List<Project>();
            foreach (var project in list)
            {
                projects.Add(project);
            }
            return projects;
        }


        public static List<User> FindAllPlanner()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            var list = collection.Find(x => true).ToList();
            var users = new List<User>();
            foreach (var user in list)
            {
                if (user.GetType().Name == "Planner")
                    users.Add(user);
            }
            return users;
        }

        public static List<User> FindAllDeveloper()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("UserBaseGuz");
            var collection = database.GetCollection<User>("User");
            var list = collection.Find(x => true).ToList();
            var users = new List<User>();
            foreach (var user in list)
            {
                if(user.GetType().Name == "Developer")
                    users.Add(user);
            }
            return users;
        }


    }
}