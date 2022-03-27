using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using mvcWithMosh.Models;
using mvcWithMosh.ViewModels;

namespace mvcWithMosh.Controllers
{
    public class MoviesController : Controller
    {
        private readonly AppDbContext Db;
        public MoviesController()
        {
            Db = new AppDbContext();
        }

        // GET: Movies
        public ActionResult Index()
        {
            try
            {
                var movies = Db.Movies.Include(m => m.Genre).ToList();
                return View(movies);

            }
            catch (Exception ex)
            {
                return View(ex.Message);

            }
        }
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")] //regex and range are ....MVC attribute route's constraints.. many more out there, google it
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Random()
        {
            //var viewModel = new RandomMovieViewModel
            //{
            //    Movie = Db.Movies.ToList(),
            //    Customer = Db.Customer.ToList()
            //};

            //return View(viewModel);
            return View();
        }

        public ViewResult NewMovie()
        {
            return View(new NewMovieVM
            {
                Movie = new Movies(),
                Genre = Db.Genre.ToList()

            });
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Save(NewMovieVM newMovie)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var viewModel = new NewMovieVM
        //        {
        //            Movie = newMovie.Movie,
        //            Genre = Db.Genre.ToList()
        //        };
        //        return View(viewModel);
        //    }
        //    if (newMovie.Movie.Id ==0)
        //    {
        //        //enter movie add logic
        //    }
        //    else
        //    {
        //        //enter movie edit logic
        //    }
        //    return View();
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewMovie(NewMovieVM newMovie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieVM
                {
                    Movie = newMovie.Movie,
                    Genre = Db.Genre.ToList()
                };
                return View(viewModel);
            }
            Movies movie = new Movies
            {
                Name = newMovie.Movie.Name,
                GenreId = newMovie.Movie.GenreId,
                NumInStock = newMovie.Movie.NumInStock,
                ReleaseDate = newMovie.Movie.ReleaseDate,
                DateAdded = DateTime.Now
            };
            Db.Movies.Add(movie);
            Db.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
        public ViewResult Details(int id)
        {
            var movieDetails = Db.Movies.Include(g => g.Genre).Where(x => x.Id == id).FirstOrDefault();
            return View(movieDetails);
        }

        public ActionResult Edit(int id)
        {
            var movie = Db.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new NewMovieVM
            {
                Movie = movie,
                Genre = Db.Genre.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(NewMovieVM movieVM)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieVM
                {
                    Movie = movieVM.Movie,
                    Genre = Db.Genre.ToList()
                };
                return View(viewModel);

            }
            var movie = Db.Movies.SingleOrDefault(x => x.Id == movieVM.Movie.Id);

            movie.Name = movieVM.Movie.Name;
            movie.GenreId = movieVM.Movie.GenreId;
            movie.ReleaseDate = movieVM.Movie.ReleaseDate;
            movie.DateAdded = movie.DateAdded;

            Db.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            var message = "";
            var movie = Db.Movies.FirstOrDefault(c => c.Id == id);
            if (movie != null)
            {
                Db.Movies.Remove(movie);
                Db.SaveChanges();
                message = "MovieRemoved";
            }
            else
            {
                message = "Error";
            }
            return Json(new { message}, JsonRequestBehavior.AllowGet);
        }
    }
}