using BookManagementSystem.Core.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Core.IRepository
{
   public interface IBookRepository
    {
        IList<AuthorDetails> GetAuthorName();
        IEnumerable<BookDetails> GetBookDetails();
      
        public bool LoginCheck(AdminLogin admin);
        void Deletebook(int bookId);
        BookDetails GetBookById(int BookId);
        BookDetails SavebookDetails(BookDetails bookDetails);
    }
}
