using MovieBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBook.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
        // GET: Index
        ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            var movies = _context.Movies.ToList();
            return View(movies);
        }

        public ActionResult Detail(int id)
        {
            var movie = _context.Movies.Where(temp => temp.MovieID == id).FirstOrDefault();
            return View(movie);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if(ModelState.IsValid)
            {
                _context.Movies.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(long id)
        {
            var movie = _context.Movies.Where(temp => temp.MovieID == id).FirstOrDefault();
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            var existingMovie = _context.Movies.Where(temp => temp.MovieID == movie.MovieID).FirstOrDefault();
            existingMovie.Name = movie.Name;
            existingMovie.ImageURL = movie.ImageURL;
            existingMovie.Producer = movie.Producer;
            existingMovie.ReleaseDate = existingMovie.ReleaseDate;
            existingMovie.Actors = movie.Actors;
            existingMovie.Description = movie.Description;
            existingMovie.TrendingStatus = movie.TrendingStatus;
            existingMovie.Ratings = movie.Ratings;
            if(ModelState.IsValid)
            {
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.Where(temp => temp.MovieID == id).FirstOrDefault();
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}