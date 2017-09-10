using RepositoryPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace RepositoryPattern.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository()
        {
            _context = new LibraryContext();
        }

        public async Task Add(Books book)
        {
            await _context.Books.InsertOneAsync(book);
        }

        public async Task<IEnumerable<Books>> Get()
        {
            return await _context.Books.Find(x=>true).ToListAsync();
        }

        public async Task<Books> Get(string id)
        {
            return await _context.Books.Find(Builders<Books>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.Books.DeleteOneAsync(Builders<Books>.Filter.Eq("Id",id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Books.DeleteManyAsync(new BsonDocument());
        }

        public async Task Update(string id, Books book)
        {
            await _context.Books.ReplaceOneAsync(m => m.Id == id, book);
        }
    }
}