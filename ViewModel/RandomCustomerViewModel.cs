using MovieRentaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentaMVC.ViewModel
{
    public class RandomCustomerViewModel
    {
        public List<Customers> customer { get; set; }
        public List<Movie> movie { get; set; }
        public List<MembershipType> membershiptype { get; set; }
    }
}