using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Core.Modal
{
  public  class BookDetails
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        
        public string BookTitle { get; set; }
        [Required]
      
        public int BookAuthor { get; set; }

        public string BookAuthors { get; set; }

        public decimal Price { get; set; }

        public IList<AuthorDetails> AuthorList { get; set; }
    }
}
