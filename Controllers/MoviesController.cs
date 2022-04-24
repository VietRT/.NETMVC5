using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext(); //disposable object
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies/Index
        public ActionResult Index()
        {
            //var movie = new List<Movie> 
            //{ 
            //    new Movie { Name = "Shriek!"},
            //    new Movie { Name = "Wall-E"}
            //};


            var customers = new List<Customer>
            {
                new Customer {Name = "customer 1"},
                new Customer {Name = "customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                //Movie = movie,
                Movie = _context.Movies.ToList(),
                Customers = customers,
            };

            //ViewData["Movie"] = movie;
            //ViewBag.RandomMovie = movie;

            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model
            return View(viewModel); //this movie object will assign to the Model (above), the View will handle the process

            //return View();
            //return new ViewResult();
            //return Content("hello world");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page=1, sortBy = "name"});
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            return View(movie);
        }

        public ActionResult Random(int? pageIndex, string sortBy)
        {
            if(!pageIndex.HasValue) 
                pageIndex = 1;

            if(String.IsNullOrEmpty(sortBy))
                sortBy = "name";
               
            //{0} and {1} just means first and second parameter, so 0 is pageIndex and 1 is sortBy
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        [HttpGet]
        //this is known as an attribute route
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}
