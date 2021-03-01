using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//This is the class that creates variables for the paging info that will be used by the Tag Helper 
namespace AdamNeumiller_BookWebsite.Models
{
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set;  }
        //This variable takes the Total Number of Items and divides it by the Items per page, accounts for rounding as well to always round up
        public int TotalPages => (int)(Math.Ceiling((decimal) TotalNumItems / ItemsPerPage));
    }
}
