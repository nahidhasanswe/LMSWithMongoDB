using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RepositoryPattern
{
    public class BorrowBooks
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public string IssueDate { get; set; }
        public string IssueBy { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public string ExpiredDate { get; set; }
    }

    public class MemberInfo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string MemberObjectId { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
    }

    public class BooksInfo
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string BookObjectId { get; set; }
        public string BookId { get; set; }
        public string MemberName { get; set; }
    }
}