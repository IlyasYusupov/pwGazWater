using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pwGazWater.Data
{
    public class User
    {
        public User(string login, string phoneNumber, string email, string password)
        {
            Login = login;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
        }

        [BsonId]
        [BsonIgnoreIfDefault]
        ObjectId _id;

        public string Login { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

    }
}