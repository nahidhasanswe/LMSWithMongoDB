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
    public class BorrowBookRepository : IBorrowBookRepository
    {
        private readonly LibraryContext _context;

        public BorrowBookRepository()
        {
            _context = new LibraryContext();
        }

        public async Task Add(BorrowBooks borrowBook)
        {
            await _context.BorrowBooks.InsertOneAsync(borrowBook);
        }

        public async Task<IEnumerable<BorrowBooks>> Get()
        {
            return await _context.BorrowBooks.Find(z=>true).ToListAsync();
        }

        public async Task<BorrowBooks> Get(string id)
        {
            return await _context.BorrowBooks.Find(Builders<BorrowBooks>.Filter.Eq("Id",id)).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
            return await _context.BorrowBooks.DeleteOneAsync(Builders<BorrowBooks>.Filter.Eq("Id", id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.BorrowBooks.DeleteManyAsync(new BsonDocument());
        }

        public async Task Update(string id, BorrowBooks borrowBook)
        {
            await _context.BorrowBooks.ReplaceOneAsync(m => m.Id == id, borrowBook);
        }
    }
}