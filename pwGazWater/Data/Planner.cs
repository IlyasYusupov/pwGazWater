using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pwGazWater.Data
{
    public class Planner : User
    {
        public Planner(string login, string phoneNumber, string email, string password) : base (login, phoneNumber, email, password)
        {

        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;

        public string NameOrganization { get; set; }

        public string OGRN { get; set; }

        public string TIN { get; set; }

        public string KPP { get; set; }

        public string NameDirecor { get; set; }

        public string NmaeChiefEngineer { get; set; }

    }
}