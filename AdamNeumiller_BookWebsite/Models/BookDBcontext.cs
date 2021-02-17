using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//How we query the database
namespace AdamNeumiller_BookWebsite.Models
{
    public class BookDBcontext : DbContext     
    {
        //Constructor. These are the options(list of things) that are passed into the database
        public BookDBcontext (DbContextOptions<BookDBcontext> options) : base (options)
        {

        }
        public DbSet<Book> Books { get; set;  }
    }
}
