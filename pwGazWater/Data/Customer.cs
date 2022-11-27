﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace pwGazWater.Data
{
    public class Customer : User
    {
        public Customer(string login, string phoneNumber, string email, string password) : base (login, phoneNumber, email, password)
        { }

        [BsonIgnoreIfNull]
        public string FullName { get; set; }

        [BsonIgnoreIfNull]
        public string Department { get; set; }

    }
}