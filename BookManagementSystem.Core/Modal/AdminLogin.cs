using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem.Core.Modal
{
   public class AdminLogin
    {
        [Key]
        public int LoginId { get; set; }
        [Required(ErrorMessage = "Please enter UserName.")]    
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter Password.")]      
        public string Password { get; set; }
    }
}
