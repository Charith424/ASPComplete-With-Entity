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
            // List<Movie> MovieList = _contex.Movies.Include(m => m.Genere).ToList();
            // return View(MovieList);
            if (User.IsInRole(UserRolesModel.CanManageMovies))
                return View();
            return View("ReadOnlyMovieList");
        }
        [Authorize(Roles = UserRolesModel.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            //List<Movie> MovieList = new List<Movie> {
            //    new Movie {Id=1,Name="Bright" },
            //    new Movie {Id=2,Name="The Greatest Showman" },
            //    new Movie {Id=3,Name="Justice League" }

            //};
            var MovieDetail = _contex.Movies.Include(m => m.Genere).SingleOrDefault(x => x.Id == id);
            if (MovieDetail == null)
            {

                return HttpNotFound();
            }
            else
            {
                NewMovie MovieDetil = new NewMovie
                {

                    Generes = _contex.Generes.ToList(),
                    Movie = MovieDetail
                };

                return View("NewMovie", MovieDetil);

            }

        }
        [Authorize(Roles = UserRolesModel.CanManageMovies)]
        public ActionResult NewMovie()
        {

            var genres = _contex.Generes.ToList();
        //    Movie movies = new Movie();
            NewMovie Movie = new NewMovie
            {
          //      Movie = movies,
                Generes = genres

            };
            return View("NewMovie", Movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = UserRolesModel.CanManageMovies)]
        public ActionResult Create(NewMovie NewMovie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var newMovie = new NewMovie
                    {
                        Movie = new Movie(),
                        Generes = _contex.Generes.ToList()

                    };
                    return View("NewMovie", newMovie);

                }
                if (NewMovie.Movie.Id == 0)
                {
                    _contex.Movies.Add(NewMovie.Movie);
                }
                else
                {
                    var custmerToDb = _contex.Movies.Include(G => G.Genere).SingleOrDefault(x => x.Id == NewMovie.Movie.Id);
                    custmerToDb.Name = NewMovie.Movie.Name;
                    custmerToDb.GenereId = NewMovie.Movie.GenereId;
                    custmerToDb.ReleaseDate = NewMovie.Movie.ReleaseDate;
                    custmerToDb.AddedDate = NewMovie.Movie.AddedDate;
                    custmerToDb.Stock = NewMovie.Movie.Stock;


                }
                _contex.SaveChanges();
                return RedirectToAction("MovieList", "Movies");

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}