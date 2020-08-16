using MovieRentaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentaMVC.ViewModel
{
    public class Customer
    {
        public Customer customer { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}