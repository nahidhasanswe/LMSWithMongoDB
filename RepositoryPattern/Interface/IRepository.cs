using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RepositoryPattern.Interface
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Members>> Get();
        Task<Members> Get(string id);
        Task Add(Members member);
        Task Update(string id, Members member);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }

    public interface IBookRepository
    {
        Task<IEnumerable<Books>> Get();
        Task<Books> Get(string id);
        Task Add(Books member);
        Task Update(string id, Books member);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }

    public interface IBorrowBookRepository
    {
        Task<IEnumerable<BorrowBooks>> Get();
        Task<BorrowBooks> Get(string id);
        Task Add(BorrowBooks member);
        Task Update(string id, BorrowBooks member);
        Task<DeleteResult> Remove(string id);
        Task<DeleteResult> RemoveAll();
    }
}