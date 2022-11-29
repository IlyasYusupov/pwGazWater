using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pwGazWater.Data
{
    public class Developer : User
    {
        public Developer(string login, string phoneNumber, string email, string password) : base (login, phoneNumber, email, password)
        {

        }

        [BsonIgnoreIfNull]
        public string Name { get; set; }

        [BsonIgnoreIfNull]
        public string OGRN { get; set; }

        [BsonIgnoreIfNull]
        public string TIN { get; set; }

        [BsonIgnoreIfNull]
        public string KPP { get; set; }

        [BsonIgnoreIfNull]
        public string Address { get; set; }

        [BsonIgnoreIfNull]
        public string HeadName { get; set; }

        [BsonIgnoreIfNull]
        public List<Project> Projects = new List<Project>();
    }
}