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
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryContext _context;

        public MemberRepository()
        {
            _context = new LibraryContext();
        }

        public async Task Add(Members member)
        {
            await _context.Members.InsertOneAsync(member);
        }

        public async Task<IEnumerable<Members>> Get()
        {
            return await _context.Members.Find(x=>true).ToListAsync();
        }

        public async Task<Members> Get(string id)
        {
            var member = Builders<Members>.Filter.Eq("Id", id);
            return await _context.Members.Find(member).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string id)
        {
           return await _context.Members.DeleteOneAsync(Builders<Members>.Filter.Eq("Id",id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await _context.Members.DeleteManyAsync(new BsonDocument());
        }

        public async Task Update(string id, Members member)
        {
            await _context.Members.ReplaceOneAsync(m=>m.Id==id,member);
        }
    }
}