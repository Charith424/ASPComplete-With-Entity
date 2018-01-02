using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPComplete.Models;
using System.Data.Entity;
namespace ASPComplete.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {    
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customer
        public ActionResult CustomerList()
        {
            //List<Customer> customer = new List<Customer> {
            //    new Customer { Id=1,Name="John Smith"},
            //    new Customer { Id=2,Name="Prethi zinta"},

            //    };
            var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customer);
        }
        public ActionResult Edit(int id)
        {
            //List<Customer> customer = new List<Customer> {
            //    new Customer { Id=1,Name="John Smith"},
            //    new Customer { Id=2,Name="Prethi zinta"},

            //    };           
            var Customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == id);
            if (Customer == null)
            {
                return HttpNotFound();

            }
            return View(Customer);
        }
        
    }
}