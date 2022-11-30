using Microsoft.AspNetCore.Routing;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading;

namespace pwGazWater.Data
{
    public class PlannerDocument
    {
        public PlannerDocument(string name, bool itsOK)
        {
            Name = name;
            ItsOK = itsOK;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;
        
        public string Name { get; set; }

        public string Text { get; set; }

        public bool ItsOK { get; set; }

    }
}