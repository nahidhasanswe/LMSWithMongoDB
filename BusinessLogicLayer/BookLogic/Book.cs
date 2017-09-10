using MongoDB.Driver;
using RepositoryPattern;
using RepositoryPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BusinessLogicLayer.BookLogic
{
    public class BookOperation
    {
        BookRepository _book;

        public BookOperation()
        {
            _book = new BookRepository();
        }

        public async Task<IEnumerable<Books>> GetAllBooks()
        {
            return await _book.Get();
        }

        public async Task<Books> GetBookById(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new HttpResponseException(ExceptionHandle.BadRequest("Id can not be null"));
            else if (id.Length != 24)
                throw new HttpResponseException(ExceptionHandle.BadRequest("Invalid Id. Please check id length"));

            try
            {
                return await _book.Get(id);
            }
            catch (FormatException e)
            {
                throw new HttpResponseException(ExceptionHandle.BadRequest("Id format is not valid. Please check again"));
            }
        }

        public async Task AddBook(Books book)
        {
            await _book.Add(book);
        }

        public async Task UpdateBook(string id,Books book)
        {
            if (string.IsNullOrEmpty(id))
                throw new Exception("Id cannot be empty");
            else if (id.Length != 24)
                throw new Exception("Invalid id");

            try
            {
                await _book.Update(id,book);
            }
            catch (FormatException e)
            {
                throw new Exception("The id format is invalid");
            }
        }

        public async Task<DeleteResult> RemoveBook(string id)
        {
            
            if (string.IsNullOrEmpty(id))
                throw new HttpResponseException(ExceptionHandle.BadRequest("Id can not be null"));
            else if (id.Length != 24)
                throw new HttpResponseException(ExceptionHandle.BadRequest("Invalid Id. Please check id length"));

            try
            {
                return await _book.Remove(id);
            }
            catch (FormatException e)
            {
                throw new HttpResponseException(ExceptionHandle.BadRequest("Id format is not valid. Please check again"));
            }
        }
    }
}