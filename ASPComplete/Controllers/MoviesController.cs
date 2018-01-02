using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPComplete.Models;
using System.Data.Entity;

namespace ASPComplete.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _contex;
        public MoviesController()
        {
            _contex = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
        }
        // GET: Movies
        public ActionResult MovieList()
        {
            ////   Movie Movie = new Movie() { Name="Shrek"};
            //List<Movie> MovieList = new List<Movie> {
            //    new Movie {Id=1,Name="Bright" },
            //    new Movie {Id=2,Name="The Greatest Showman" },
            //    new Movie {Id=3,Name="Justice League" }

            //};
            List<Movie> MovieList = _contex.Movies.Include(m=>m.Genere).ToList();
            return View(MovieList);
        }
        public ActionResult Edit(int id)
        {
            //List<Movie> MovieList = new List<Movie> {
            //    new Movie {Id=1,Name="Bright" },
            //    new Movie {Id=2,Name="The Greatest Showman" },
            //    new Movie {Id=3,Name="Justice League" }

            //};
            var MovieDetail = _contex.Movies.Include(m => m.Genere).SingleOrDefault(x => x.Id == id);
            if (MovieDetail == null) {

                return HttpNotFound();
            }
            return View(MovieDetail);
        }
    }
}