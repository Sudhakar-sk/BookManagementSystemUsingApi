using BookManagementSystem.Core.IRepository;
using BookManagementSystem.Core.IService;
using BookManagementSystem.Core.Modal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Service.Service
{
   public class BookService: IBookService
    {
        #region Declaration
        readonly IBookRepository _IBookRepository;
        #endregion

        #region Constructor
        public BookService(IBookRepository BookRepositories)
        {
            _IBookRepository = BookRepositories;
        }
        #endregion

        #region Login
        public bool LoginCheck(AdminLogin admin)
        {
            return _IBookRepository.LoginCheck(admin);
        }
        #endregion

        #region Get All Author Name List
        public IList<AuthorDetails> GetAuthorName()
        {
            return _IBookRepository.GetAuthorName();
            
        }
        #endregion

        #region Get All Book Details
        public IEnumerable<BookDetails> GetBookDetails()
        {
            return _IBookRepository.GetBookDetails();
        }
        #endregion

        #region Get Book Details By using Id
        public BookDetails GetBookById(int bookId)
        {
            return _IBookRepository.GetBookById(bookId);
        }

        #endregion

        #region InsertBookDetails
        public void InsertBookDetails(BookDetails book)
        {
            _IBookRepository.SavebookDetails(book);
        }
        #endregion

        #region  UpdateBookDetails

        public void UpdateBookDetails(BookDetails book)
        {
            _IBookRepository.SavebookDetails(book);
        }

        #endregion

        #region Deletebook
        public void Deletebook(int bookId)
        {
            _IBookRepository.Deletebook(bookId);
        }
        #endregion

      

    }
}
