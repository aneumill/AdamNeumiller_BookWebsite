using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AdamNeumiller_BookWebsite.Models.ViewModels
{
    public class BookListViewModel
    {
        //Iterative object based on the book class
        public IEnumerable<Book> Books { get; set;}
        //Paging info objectff
        public PagingInfo PagingInfo { get; set; }
        //Tracks the current filter's category
        public string CurrentCategory { get; set;  }

    }
}
