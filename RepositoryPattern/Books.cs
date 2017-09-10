using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace RepositoryPattern
{
    public class Books
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }

    }

    public class Location
    {
        public int RackNo { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
    }

    public class Edition
    {
        public string EditionYear { get; set; }
        public string Quantity { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public string EntryDate { get; set; }
    }
}