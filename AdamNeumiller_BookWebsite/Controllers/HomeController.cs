using AdamNeumiller_BookWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AdamNeumiller_BookWebsite.Models.ViewModels;

namespace AdamNeumiller_BookWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private iBookRepository _repository;

        //Make a variable that sets the number of pages viewable through pagination
        public int ItemsPerPage = 5; 

        public HomeController(ILogger<HomeController> logger, iBookRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // Pass int page = 1 and returns 
        public IActionResult Index(string category, int pageNum = 1)
        {
            //Returns the proper view with correct number of fields  (This is a query written out in Linq)
            return View(new BookListViewModel
            {
               
                Books = _repository.Books
                .Where(p => category == null || p.Category == category)
                //Lambda Function to dynamically print the appropriate number of fields return
                .OrderBy(p => p.BookId)
                .Skip((pageNum - 1) * ItemsPerPage )
                .Take(ItemsPerPage)
                
                ,
                //Creating a new object Paging Info based on  the Paging Info Model 
                PagingInfo = new PagingInfo
                {
                    //Inputting the values into 
                    CurrentPage = pageNum, //starts with page 1 
                    ItemsPerPage = ItemsPerPage, //Sets Items to Page to the Page Size as delcared in the model
                    TotalNumItems = category == null ? _repository.Books.Count() :
                        _repository.Books.Where(x => x.Category == category).Count()
                    
                    
       
                    //Total number of books pulled from the repository 
                },
                CurrentCategory = category

            }); ;




        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
