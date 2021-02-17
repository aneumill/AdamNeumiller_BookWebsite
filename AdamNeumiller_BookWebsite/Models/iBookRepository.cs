using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Template
namespace AdamNeumiller_BookWebsite.Models
{
    //Creates a querable book object
    public interface iBookRepository
    {
        IQueryable<Book> Books { get;   }

    }
}
