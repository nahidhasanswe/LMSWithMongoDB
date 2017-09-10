using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace RepositoryPattern
{
    public class LibraryContext
    {
        public IMongoDatabase _db { get;}

        public LibraryContext()
        {
            MongoClient client = new MongoClient(ConfigurationManager.AppSettings.Get("connectionString"));
            _db = client.GetDatabase(ConfigurationManager.AppSettings.Get("Database"));
        }

        public IMongoCollection<Members> Members
        {
            get
            {
                return _db.GetCollection<Members>("Members");
            }
        }

        public IMongoCollection<Books> Books
        {
            get
            {
                return _db.GetCollection<Books>("Books");
            }
        }

        public IMongoCollection<BorrowBooks> BorrowBooks
        {
            get
            {
                return _db.GetCollection<BorrowBooks>("BorrowBooks");
            }
        }

    }

}