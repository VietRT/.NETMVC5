using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        //GET /api/Movies

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<MoviesDto> GetMovies()
        {
            var moviesDto = _context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MoviesDto>);

            return moviesDto;
        } 

        //GET  /api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);

            if(movie == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MoviesDto>(movie));
        }

        [HttpPost]
        //POST /api/Movies
        public IHttpActionResult CreateMovie(MoviesDto moviesDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MoviesDto, Movie>(moviesDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            moviesDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), moviesDto);

        }

        [HttpPut]
        //PUT /api/Movies/1
        public void UpdateMovie(int id, MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(moviesDto, movieInDb); //the compiler can infer our source and target types so we don't need the <CustomersDto, Customer>

            _context.SaveChanges();

        }

        [HttpDelete]
        //DELETE /api/Movies/1
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }

    }
}