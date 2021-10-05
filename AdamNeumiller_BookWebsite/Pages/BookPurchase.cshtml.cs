using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdamNeumiller_BookWebsite.Infrastructure;
using AdamNeumiller_BookWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AdamNeumiller_BookWebsite.Pages
{
     
    public class BookPurchaseModel : PageModel
    {
        private iBookRepository _repository;
        //CONSTRUCTOR for the private repository variable
        public BookPurchaseModel (iBookRepository repo, Cart cartService )

        {
            _repository = repo;
            Cart = cartService;
        }
        //properties
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }
 
        //Methods 
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long bookID, string returnURL)
        {
            Book book = _repository.Books
                .FirstOrDefault(p => p.BookId == bookID);
            Cart.AddItem(book, 1);
            return RedirectToPage(new { returnUrl = returnURL });
            //Book book = _repository.Books.FirstOrDefault(p => p.BookID == bookID);
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            //Cart.AddItem(book, 1);
            //HttpContext.Session.SetJson("cart", Cart);
            //return RedirectToPage(new { returnURL = returnURL });
        }
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
