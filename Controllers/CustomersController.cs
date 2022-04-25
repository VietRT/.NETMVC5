using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        //var
        //List<Customer> customer = new List<Customer>
        //    {
        //        new Customer { Id = 1,Name = "John Smith"},
        //        new Customer { Id = 2, Name = "Mary Williams"}
        //    };

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext(); //disposable object
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer) /*automatically binds request data to this argument, customer*/
        {
            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id); /*using Single means that if a customer is not found it will throw an exception*/

                //Mapper.map(customer, customerInDb)

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubstribedToNewsLetter = customer.IsSubstribedToNewsLetter;
            }

           /* _context.Customers.Add(customer);*/ /*this only saves in memory*/
            _context.SaveChanges();

            //return View();
            return RedirectToAction("Index", "Customers"); /*the customers controller with the index action*/
        }

        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {
            var viewModel = new CustomersMovieViewModel
            {
                //Customers = customer
                Customers = _context.Customers.Include(x => x.MembershipType).ToList() //the include method will tell entity to load the data for
                                                                                        //Customer from the db and MembershipType along with it (called eager loading)

        };

            //var customer = _context.Customers.ToList(); //executes query immediately by using ToList() method

            //return View(viewModel); //View will assign to ViewData.Models on its own
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(x => x.MembershipType).SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id); /*lambda expression*/

            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel); /*without passing "New", which is the View in Views/Customers/New.cshtml, this will look for the view called Edit instead*/
                   
        }

    //    [HttpGet]
    //    [Route("Customers/Details/1")]
    //    public ActionResult JohnsDetails()
    //    {
    //        var customer = new Customer() { Name = "John Smith" };

    //        return View(customer); //currently this works for any id
    //    }

    //    [HttpGet]
    //    [Route("Customers/Details/2")]
    //    public ActionResult MarysDetails()
    //    {
    //        var customer = new Customer() { Name = "Mary Williams" };

    //        return View(customer); //currently this works for any id
    //    }

    }
}