using Microsoft.AspNetCore.Routing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading;

namespace pwGazWater.Data
{
    public class Document
    {
        public Document(string name, string path, bool itsOK)
        {
            Name = name;
            Path = path;
            ItsOK = itsOK;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;
        
        public string Name { get; set; }

        public string Path { get; set; }

        public bool ItsOK { get; set; }

    }
}