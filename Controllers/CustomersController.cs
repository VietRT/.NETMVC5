using System;
using System.Collections.Generic;
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
        List<Customer> customer = new List<Customer>
            {
                new Customer { Id = 1,Name = "John Smith"},
                new Customer { Id = 2, Name = "Mary Williams"}
            };

        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {
            var viewModel = new RandomMovieViewModel
            {
                Customers = customer,
            };

            return View(viewModel); //View will assign to ViewData.Models on its own
        }

        [HttpGet]
        [Route("Customers/Details/1")]
        public ActionResult JohnsDetails()
        {
            var customer = new Customer() { Name = "John Smith" };

            return View(customer); //currently this works for any id
        }

        [HttpGet]
        [Route("Customers/Details/2")]
        public ActionResult MarysDetails()
        {
            var customer = new Customer() { Name = "Mary Williams" };

            return View(customer); //currently this works for any id
        }

    }
}