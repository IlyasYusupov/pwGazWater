using Microsoft.AspNetCore.Routing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading;

namespace pwGazWater.Data
{
    public class DeveloperDocument
    {
        public DeveloperDocument(string name, bool itsOK)
        {
            Name = name;
            ItsOK = itsOK;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;
        
        public string Name { get; set; }

        public string FileName { get; set; }

        public bool ItsOK { get; set; }

    }
}