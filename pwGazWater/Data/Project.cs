using Microsoft.AspNetCore.Routing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading;

namespace pwGazWater.Data
{
    public class Project
    {
        public Project(string name, string type, User developer, User planner)
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

        public User Developer { get; set; }

        public User Planner { get; set; }

        [BsonIgnoreIfNull]
        public List<DeveloperDocument> Documents = new List<DeveloperDocument>();

        [BsonIgnoreIfNull]
        public List<PlannerDocument> Documentss = new List<PlannerDocument>();

    }
}