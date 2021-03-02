using AdamNeumiller_BookWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamNeumiller_BookWebsite.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private iBookRepository _repository;

        public NavigationMenuViewComponent(iBookRepository r)
        {
            _repository = r;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(_repository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
                
                
                
        }
    }

}