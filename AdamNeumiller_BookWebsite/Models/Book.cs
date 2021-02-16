using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AdamNeumiller_BookWebsite.Models
{
    public class Book
    {
        [Key, Required]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public string ISBN { get; set; }
        //Regular Expression for Regex
        [Required, RegularExpression("[7,8,9]{3}-[0-9]{10}")]
        public string Category { get; set; }
        [Required]
        public double Price { get; set;  }


    }
}
