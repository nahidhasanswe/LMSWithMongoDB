using BusinessLogicLayer.BorrowBookLogic;
using RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace LMSWithMongoDB.Areas.BorrowBook.Controllers
{
    [RoutePrefix("api/BorrowBook/Operation")]
    public class BorrowBookController : ApiController
    {
        BorrowBookOperation _borrowBook = new BorrowBookOperation();

        [HttpPost]
        [Route("AddBorrowBook")]
        public async Task<IHttpActionResult> AddBorrowBook(BorrowBooks borrowBook)
        {
            try
            {
                await _borrowBook.AddBorrowBook(borrowBook);
                return Ok("Successfully added Borrow Book List");
            }
            catch
            {
                return BadRequest("Borrow Book id can not be duplicated");
            }
        }

        [HttpGet]
        [Route("GetBorrowBooks")]
        public async Task<IHttpActionResult> GetBorrowBook()
        {
            return Ok(await _borrowBook.GetBorrowBookList());
        }

        [HttpGet]
        [Route("GetBorrowBooks/{id}")]
        public async Task<IHttpActionResult> GetBorrowBook(string id)
        {
            var _BorrowBook = await _borrowBook.GetBorrowBookListById(id);
            if (_BorrowBook == null)
                return BadRequest("There is no Borrow List found");
            return Ok(_BorrowBook);
        }

        [HttpPost]
        [Route("UpdateBorrowBook")]
        public async Task<IHttpActionResult> UpdateBorrowBook(BorrowBooks borrowBook)
        {
            await _borrowBook.UpdateBorrowBook(borrowBook.Id, borrowBook);
            return Ok("Successfully update the Borrow Book information");
        }

        [HttpGet]
        [Route("RemoveBorrowBook/{id}")]
        public async Task<IHttpActionResult> RemoveBorrowBook(string id)
        {
            await _borrowBook.RemoveBorrowBook(id);
            return Ok("Successfully remove the Borrow Book information");
        }
    }
}
