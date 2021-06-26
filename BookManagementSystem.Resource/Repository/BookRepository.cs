using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagementSystem.Core.Modal;
using BookManagementSystem.Entity;
using BookManagementSystem.Core.IRepository;

namespace BookManagementSystem.Resource.Repository
{
   public class BookRepository: IBookRepository
    {

        #region Login
        public bool LoginCheck(AdminLogin admin)
        {
            var BookDB = new BookmanagementsystemContext();
            var logindetails = BookDB.admin_Login.Where(x => x.Username == admin.Username && x.password == admin.Password).SingleOrDefault();

            if (logindetails != null)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        #endregion

        #region NameList
        public IList<AuthorDetails> GetAuthorName()
        {
            List<AuthorDetails> NameList = new List<AuthorDetails>();
            using (var entites = new BookmanagementsystemContext())
            {
                var dbAuthorName = entites.author_Name.Where(x => x.Is_Deleted == false).ToList();
                if (dbAuthorName != null)
                {
                    foreach (var dbname in dbAuthorName)
                    {
                        AuthorDetails authorName = new AuthorDetails();
                        authorName.AuthorId = dbname.Author_Id;
                        authorName.BookAuthor = dbname.Book_Author;
                        NameList.Add(authorName);
                    }
                }
            }
            return NameList;
        }
        #endregion

        #region Get All Book Details from DB
        public IEnumerable<BookDetails> GetBookDetails()
        {
            IList<BookDetails> bookList = new List<BookDetails>();
            var bookDB = new BookmanagementsystemContext();
            bookList = (from book in bookDB.book_Details
                        join author in bookDB.author_Name
on
book.Book_Author equals
author.Author_Id
                        where book.Is_Deleted == false && author.Is_Deleted == false

                        select new BookDetails
                        {
                            BookId = book.Book_Id,
                            BookTitle = book.Book_Title,
                            BookAuthors = author.Book_Author,
                            Price = book.Price


                        }).ToList();

            return bookList;
        }
        #endregion

        #region get Book detail by using Book Id
        public BookDetails GetBookById(int BookId)
        {

            var BookDB = new BookmanagementsystemContext();
            var Book = (from books in BookDB.book_Details
                        join author in BookDB.author_Name
                        on
                        books.Book_Author equals author.Author_Id
                        where books.Book_Id == BookId 
                        && books.Is_Deleted == false 
                        && author.Is_Deleted == false
                        select new BookDetails
                        {
                            BookId = books.Book_Id,
                            BookTitle = books.Book_Title,
                            BookAuthor = books.Book_Author,
                            Price = books.Price
                        }).SingleOrDefault();
            return Book;

        }
        #endregion

        #region Save Book Details
        public BookDetails SavebookDetails(BookDetails bookDetails)
        {
            using var entities = new BookmanagementsystemContext();
            book_Details _dbBookDetails = null;
            bool IsRecordExists = false;
            if (bookDetails.BookId > 0)
            {
                _dbBookDetails = entities.book_Details.SingleOrDefault(bd => bd.Book_Id == bookDetails.BookId && !bd.Is_Deleted);
            }
            #region To check record exist or not
            if (_dbBookDetails != null && _dbBookDetails.Book_Id > 0)
            {
                IsRecordExists = true;
            }
            #region Insert new Record
            else
            {
                _dbBookDetails = new book_Details();
            }
            #endregion
            if (bookDetails.BookId > 0)
            {
                _dbBookDetails.Book_Id = bookDetails.BookId;
            }
            #endregion

            _dbBookDetails.Book_Title = bookDetails.BookTitle;
            _dbBookDetails.Book_Author = bookDetails.BookAuthor;
            _dbBookDetails.Price = bookDetails.Price;
            //_dbBookDetails.Is_Deleted = false;
            //_dbBookDetails.Update_Time_Stamp = DateTime.Now;

            if (!IsRecordExists)
            {
                _dbBookDetails.Create_Time_Stamp = DateTime.Now;
                entities.book_Details.Add(_dbBookDetails);
            }
            entities.SaveChanges();

            return bookDetails;
        }
        #endregion

        #region Delete book Details 

        public void Deletebook(int bookId)
        {
            var BookDB = new BookmanagementsystemContext();
            var book = BookDB.book_Details.Where(x => x.Book_Id == bookId && x.Is_Deleted == false).SingleOrDefault();
            if (book != null)
            {
                book.Is_Deleted = true;
                book.Update_Time_Stamp = DateTime.Now;
                BookDB.SaveChanges();
            }


        }
        #endregion       

    }
}
