using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdamNeumiller_BookWebsite.Models
{
    //This is the model for the Book Databse, See seed data to edit the inputs
    public class Book
    {
        [Key, Required]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        public string AuthorMiddleInitial { get; set; } = "";
        [Required]
        public string AuthorLastName { get; set; }
      
        [Required]
        public string Publisher { get; set; }
        [Required, RegularExpression("[0-9]{3}-[0-9]{10}")]
        public string ISBN { get; set; }
        //Regular Expression for Regex
        [Required]
        public string Classification { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set;  }
        [Required]
        public int PageNumber { get; set; }


    }
}
