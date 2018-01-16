using ASPComplete.Dtos;
using ASPComplete.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASPComplete.Controllers
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovie()
        {
            var Movie = _context.Movies
                .Include(m => m.Genere)
                .ToList()
                .Select(Mapper.Map<Movie, MoviesDto>);
            return Ok(Movie);

        }

        public IHttpActionResult GetMovie(int id)
        {
            var Movie = _context.Movies.Include(m => m.Genere).SingleOrDefault(m => m.Id == id);
            if (Movie == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Movie, MoviesDto>(Movie));
        }
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MoviesDto MovieDto)
        {
            if (!ModelState.IsValid)
            {
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }
            var Movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (Movie == null)
            {
                NotFound();
            }
            Mapper.Map<MoviesDto, Movie>(MovieDto, Movie);

            Movie.Name = MovieDto.Name;
            Movie.GenereId = MovieDto.GenereId;
            Movie.ReleaseDate = MovieDto.ReleaseDate;
            Movie.AddedDate = MovieDto.AddedDate;
            Movie.Stock = MovieDto.Stock;
            _context.SaveChanges();
            return Ok();

        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var Movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (Movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(Movie);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto MovieDto)
        {
            if (!ModelState.IsValid)
            {
                // throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }
            var Movie = Mapper.Map<MoviesDto, Movie>(MovieDto);
            _context.Movies.Add(Movie);
            _context.SaveChanges();
            MovieDto.Id = Movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + Movie.Id), MovieDto);

        }
    }
}
