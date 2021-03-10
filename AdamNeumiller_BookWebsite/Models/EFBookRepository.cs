using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamNeumiller_BookWebsite.Models
{
    //This class inherits from iBookRepository
    public class EFBookRepository : iBookRepository
    {
        private BookDBcontext _context;

        //Constructor for the class
        public EFBookRepository(BookDBcontext context)
        {
            _context = context;
        }


        public IQueryable<Book> Books => _context.Books;
    }
}
