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
        public BookLocation Location { get; set; }
        public BookEdition Edition { get; set; }

    }

    public class BookLocation
    {
        public int RackNo { get; set; }
        public int RowNo { get; set; }
        public int ColNo { get; set; }
    }

    public class BookEdition
    {
        public string EditionYear { get; set; }
        public int Quantity { get; set; }
        public BsonDateTime EntryDate { get; set; }
    }
}