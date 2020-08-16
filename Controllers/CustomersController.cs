using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieRentaMVC.Models;
using MovieRentaMVC.ViewModel;
using MovieRentaMVC.Views;
using System.Data.Entity.Validation;

namespace MovieRentaMVC.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
        /*    var customers = _context.customers.ToList();
            var viewModel = new RandomCustomerViewModel
            {
                customer = customers,
                membershiptype = _context.membershiptypes.ToList()
            };*/
            return View();
        }

        public ActionResult New()
        {
            var membershiptypes = _context.membershiptypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customers(),
                MembershipTypes = membershiptypes
            };
            return View("CustomerForm",viewModel);
        }

        /// <summary>
        /// The MVC framework will automatically map request data to this object. This is called model binding
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(Customers customer)
        {
            if (!ModelState.IsValid) {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.membershiptypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
             if (customer.Id == 0)
                 _context.customers.Add(customer);
             else {
                 var customerInDb = _context.customers.Single(c => c.Id == customer.Id);
                 customerInDb.Name = customer.Name;
                 customerInDb.BirthDate = customer.BirthDate;
                 customerInDb.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;
                 customerInDb.MembershipTypeId = customer.MembershipTypeId;
             }
             _context.SaveChanges();     
             return RedirectToAction("Index", "Customers"); 
        }
        public ActionResult Details(int id)
        {
            var customer = _context.customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.membershiptypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}