using MongoDB.Driver;
using RepositoryPattern;
using RepositoryPattern.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BusinessLogicLayer.BorrowBookLogic
{
    public class BorrowBookOperation
    {
        BorrowBookRepository _borrowBook;
        public BorrowBookOperation()
        {
            _borrowBook = new BorrowBookRepository();
        }

        public async Task<IEnumerable<BorrowBooks>> GetBorrowBookList()
        {
            return await _borrowBook.Get();
        }

        public async Task<BorrowBooks> GetBorrowBookListById(string id)
        {
           
            if (string.IsNullOrEmpty(id))
                throw new HttpResponseException(ExceptionHandle.BadRequest("Id can not be null"));
            else if (id.Length != 24)
                throw new HttpResponseException(ExceptionHandle.BadRequest("Invalid Id. Please check id length"));

            try
            {
                return await _borrowBook.Get(id);
            }
            catch (FormatException e)
            {
                throw new HttpResponseException(ExceptionHandle.BadRequest("Id format is not valid. Please check again"));
            }
        }

        public async Task AddBorrowBook(BorrowBooks borrowBook)
        {
            await _borrowBook.Add(borrowBook);
        }

        public async Task UpdateBorrowBook(string id,BorrowBooks borrowBook)
        {
            await _borrowBook.Update(id,borrowBook);
        }

        public async Task<DeleteResult> RemoveBorrowBook(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new HttpResponseException(ExceptionHandle.BadRequest("Id can not be null"));
            else if (id.Length != 24)
                throw new HttpResponseException(ExceptionHandle.BadRequest("Invalid Id. Please check id length"));

            try
            {
                return await _borrowBook.Remove(id);
            }
            catch (FormatException e)
            {
                throw new HttpResponseException(ExceptionHandle.BadRequest("Id format is not valid. Please check again"));
            }
            
        }
    }
}