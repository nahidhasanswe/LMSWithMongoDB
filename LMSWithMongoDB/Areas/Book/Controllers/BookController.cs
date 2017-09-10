using BusinessLogicLayer.BookLogic;
using MongoDB.Driver;
using RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LMSWithMongoDB.Areas.Book.Controllers
{
    [RoutePrefix("api/Book/Operation")]
    public class BookController : ApiController
    {
        BookOperation _book = new BookOperation();

        [HttpPost]
        [Route("AddBook")]
        public async Task<IHttpActionResult> AddBook(Books book)
        { 
            try
            {
                await _book.AddBook(book);
                return Ok("Successfully added Book");
            }
            catch(MongoWriteException e)
            {
                return BadRequest("Bookid can not be duplicated. Please check BookId");
            }catch(Exception e)
            {
                return BadRequest("Internal Server Problem");
            }
        }
        
        [HttpGet]
        [Route("GetBooks")]
        public async Task<IHttpActionResult> GetBook()
        {
            return Ok(await _book.GetAllBooks());
        }
        
        [HttpGet]
        [Route("GetBooks/{id}")]
        public async Task<IHttpActionResult> GetBook(string id)
        {
            var book = await _book.GetBookById(id);
            if (book == null)
                return BadRequest("There is no book found");
            return Ok(book);
        }
        
        [HttpPost]
        [Route("UpdateBook")]
        public async Task<IHttpActionResult> UpdateBook(Books book)
        {
            await _book.UpdateBook(book.Id, book);
            return Ok("Successfully update the book information");
        }

        [HttpGet]
        [Route("RemoveBook/{id}")]
        public async Task<IHttpActionResult> RemoveBook(string id)
        {
            await _book.RemoveBook(id);
            return Ok("Successfully remove the book information");
        }
    }
}
