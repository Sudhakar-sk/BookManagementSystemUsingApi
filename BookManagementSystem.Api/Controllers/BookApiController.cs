using BookManagementSystem.Core.IService;
using BookManagementSystem.Core.Modal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookApiController : Controller
    {
        #region Declaration
        private readonly IBookService _IBookService;
        #endregion

        #region Constructor Injection
        public BookApiController(IBookService bookServices)
        {
            _IBookService = bookServices;
        }
        #endregion

        #region Login
        [HttpPost]
        public ActionResult LoginCheck(AdminLogin admin)
        {
            var login = _IBookService.LoginCheck(admin);
            if (login == true)
            {
                return Ok(true);
            }
            return NotFound();
        }
        #endregion

        #region Get Author Name List
        [HttpGet]
        public IActionResult GetAuthorName()
        {
            var name = _IBookService.GetAuthorName();
            return Ok(name);
        }
        #endregion

        #region Get All BookDetails
        [HttpGet]
        public IActionResult BookDetailList()
        {
            var books = _IBookService.GetBookDetails();
            return Ok(books);
        }
        #endregion

        #region Get book By using Id
        [HttpGet]
        public ActionResult GetBookById(int bookId)
        {

            BookDetails book = _IBookService.GetBookById(bookId);
            book.AuthorList = _IBookService.GetAuthorName();
            return Ok(book);
        }
        #endregion

        #region Insert Book[Post]
        [HttpPost]
        public void InsertBookDetails(BookDetails book)
        {
            _IBookService.InsertBookDetails(book);
        }
        #endregion

        #region Update Book[Put]
        [HttpPut]
        public void UpdateBookDetails(BookDetails book)
        {
            _IBookService.UpdateBookDetails(book);
        }
        #endregion

        #region Delete Book

        [HttpDelete]
        public void DeleteBook(int bookId)
        {
            _IBookService.Deletebook(bookId);
        }
        #endregion
 

    }
}
