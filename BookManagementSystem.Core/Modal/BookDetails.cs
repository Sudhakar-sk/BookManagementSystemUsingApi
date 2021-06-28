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
        [Required(ErrorMessage = "Please enter Book Title.")]
        
        public string BookTitle { get; set; }
        [Required(ErrorMessage = "Please Select Author name.")]
      
        public int BookAuthor { get; set; }

        public string BookAuthors { get; set; }
        [Required(ErrorMessage = "Please enter Book Price.")]
        public decimal Price { get; set; }

        public IList<AuthorDetails> AuthorList { get; set; }

        public int Index{ get; set; }
    }
}
