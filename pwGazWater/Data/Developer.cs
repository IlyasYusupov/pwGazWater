using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pwGazWater.Data
{
    public class Developer : User
    {
        public Developer(string login, string phoneNumber, string email, string password) : base (login, phoneNumber, email, password)
        {

        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;

        public string Name { get; set; }

        public string OGRN { get; set; }

        public string TIN { get; set; }

        public string KPP { get; set; }

        public string Address { get; set; }

        public string HeadName { get; set; }

    }
}