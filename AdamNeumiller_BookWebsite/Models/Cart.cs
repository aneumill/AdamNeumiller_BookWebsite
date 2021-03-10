using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamNeumiller_BookWebsite.Models
{
    public class Cart
    {
        //Create new list objects for Cartlines
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        //Method that adds a book item to the list objectl ines 
        public virtual void AddItem(Book book, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookId == book.BookId)
                .FirstOrDefault();
            //if line is null then add to list
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quanitity = qty
                });
            }
            else
            {
                line.Quanitity += qty;
            }
        }
        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookId == book.BookId);
        public virtual void Clear() => Lines.Clear();
        public decimal ComputeTotalSum() => Lines.Sum(e => (decimal)e.Book.Price * e.Quanitity); //Price is hard-coded

        public class CartLine
        {
            public int CartLIneID { get; set;  }
            public Book Book { get; set;  }
            public int Quanitity { get; set;  }

        }
    }
}
