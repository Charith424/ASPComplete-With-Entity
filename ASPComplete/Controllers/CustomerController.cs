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
            //var customer = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customer);
            if (User.IsInRole(UserRolesModel.CanManageMovies))
                return View();
            return View("ReadOnlyCustomerList");
        }
        [Authorize(Roles = UserRolesModel.CanManageMovies)]
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
            NewCustomerModel viewModel = new NewCustomerModel
            {
                Customer = Customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("NewCustomer", viewModel);
        }
        [Authorize(Roles = UserRolesModel.CanManageMovies)]
        public ActionResult NewCustomer()
        {
            var membershipType = _context.MembershipTypes.ToList();
            NewCustomerModel newcustomer = new NewCustomerModel
            {
                MembershipTypes = membershipType,
                //Customer = new Customer()
            };
            return View(newcustomer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRolesModel.CanManageMovies)]

        public ActionResult Create(NewCustomerModel NewCustomer)
        {
            try
            {
                if (!ModelState.IsValid) {
                    var reshowdetail = new NewCustomerModel
                    {
                        Customer = new Customer(),
                        MembershipTypes = _context.MembershipTypes.ToList()

                    };
                    return View("NewCustomer", reshowdetail);

                }
                if (NewCustomer.Customer.Id == 0)
                {
                    _context.Customers.Add(NewCustomer.Customer);
                }
                else
                {
                    var custmerToDb = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == NewCustomer.Customer.Id);
                    custmerToDb.Name = NewCustomer.Customer.Name;
                    custmerToDb.BirthDate = NewCustomer.Customer.BirthDate;
                    custmerToDb.MembershipTypeId = NewCustomer.Customer.MembershipTypeId;
                    custmerToDb.IsSubsceibedToNewsLetter = NewCustomer.Customer.IsSubsceibedToNewsLetter;

                }
                _context.SaveChanges();
                return RedirectToAction("CustomerList", "Customer");

            }
            catch (Exception)
            {

                throw;
            }
           

        }
    }
}
