using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pwGazWater.Data
{
    public class Planner : User
    {
        public Planner(string login, string phoneNumber, string email, string password) : base (login, phoneNumber, email, password)
        {

        }

        [BsonIgnoreIfNull]
        public string NameOrganization { get; set; }

        [BsonIgnoreIfNull]
        public string OGRN { get; set; }

        [BsonIgnoreIfNull]
        public string TIN { get; set; }

        [BsonIgnoreIfNull]
        public string KPP { get; set; }

        [BsonIgnoreIfNull]
        public string NameDirecor { get; set; }

        [BsonIgnoreIfNull]
        public string NameChiefEngineer { get; set; }

        [BsonIgnoreIfNull]
        public List<Project> Projects = new List<Project>();
    }
}