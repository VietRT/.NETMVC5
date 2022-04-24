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

        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {
            var viewModel = new RandomMovieViewModel
            {
                //Customers = customer
                Customers = _context.Customers.Include(x => x.MembershipType ).ToList() //the include method will tell entity to load the data for
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