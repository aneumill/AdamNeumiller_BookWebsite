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
        public BookDBcontext (DbContextOptions<BookDBcontext> options) : base (options)
        {

        }
        public DbSet<Book> Books { get; set;  }
    }
}
