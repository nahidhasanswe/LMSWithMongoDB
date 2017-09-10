using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RepositoryPattern
{
    public class Members
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("MemberId")]
        public string MemberId { get; set; }
        [BsonElement("MemberName")]
        public string MemberName { get; set; }
        [BsonElement("Proffession")]
        public string Proffession { get; set; }
        [BsonElement("Address")]
        public ContactAddress Address { get; set; }
        [BsonElement("Account")]
        public AccountInfo Account { get; set; }
    }

    public class ContactAddress
    {
        public string Street { get; set; }
        public string City { get; set; }
        [StringLength(5,MinimumLength =4)]
        public string ZipCode { get; set; }
        [StringLength(12, MinimumLength = 11)]
        public string ContatcNo { get; set; }
    }

    public class AccountInfo
    {
        public int Balance { get; set; }
    }
}