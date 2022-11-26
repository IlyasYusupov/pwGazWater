using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pwGazWater.Data
{
    public class Customer : User
    {
        public Customer(string login, string phoneNumber, string email, string password) : base (login, phoneNumber, email, password)
        {

        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;

        public string FullName { get; set; }

        public string Department { get; set; }

    }
}