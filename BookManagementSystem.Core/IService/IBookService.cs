using BookManagementSystem.Core.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Core.IService
{
   public interface IBookService
    {

        IEnumerable<BookDetails> GetBookDetails();
        public bool LoginCheck(AdminLogin admin);
        void Deletebook(int bookId);
        BookDetails GetBookById(int BookId);
        IList<AuthorDetails> GetAuthorName();
        void InsertBookDetails(BookDetails student);
        void UpdateBookDetails(BookDetails book);
    }
}
