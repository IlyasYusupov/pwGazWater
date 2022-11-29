using Microsoft.AspNetCore.Routing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading;

namespace pwGazWater.Data
{
    public class Project
    {
        public Project(string name, string type, Developer developer, Planner planner)
        {
            Name = name;
            Type = type;
            Developer = developer;
            Planner = planner;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;
        
        public string Name { get; set; }

        public string Type { get; set; }

        public Developer Developer { get; set; }

        public Planner Planner { get; set; }

        [BsonIgnoreIfNull]
        public string Document { get; set; }

    }
}