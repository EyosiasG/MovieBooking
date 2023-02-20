using MovieBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MovieBook.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();//Database connection

        //Function which returns list of movies in the database
        //Viewbags are used to as an html output in the html page
        public ActionResult Index()
        {
            var movies = _context.Movies.Where(temp => temp.TrendingStatus == true).ToList();
            ViewBag.TrendingMovies = movies; //Views movies of trending status in the html page
            movies = _context.Movies.Where(temp => temp.Genre == "1").ToList();//returns list movies of Action Genre
            ViewBag.ActionMovies = movies;
            movies = _context.Movies.Where(temp => temp.Genre == "2").ToList();//returns list movies of Comedy Genre
            ViewBag.ComedyMovies = movies;
            movies = _context.Movies.Where(temp => temp.Genre == "3").ToList();//returns list movies of Romance Genre
            ViewBag.RomanceMovies = movies;
            movies = _context.Movies.Where(temp => temp.Genre == "4").ToList();//returns list movies of Drama Genre
            ViewBag.DramaMovies = movies;
            movies = _context.Movies.Where(temp => temp.Genre == "5").ToList();//returns list movies of Horror Genre
            ViewBag.HorrorMovies = movies;
            movies = _context.Movies.Where(temp => temp.Genre == "6").ToList();//returns list movies of Animation Genre
            ViewBag.AnimationMovies = movies;
            return View(movies);
        }

        //Function for searching list of cinemas and movies
        //Results are assigned to viewbags and displayed in the HTML page
        public ActionResult Search(string searchString)
        {
            var movies = _context.Movies.ToList();
            var cinema = _context.Cinemas.ToList();
            List<Movie> filteredMovies = new List<Movie>();
            List<Cinema> filteredCinemas = new List<Cinema>();

            //Matches the searchstring to the names of cinemas/movies
            if(!string.IsNullOrEmpty(searchString))
            {
               filteredMovies = movies.Where(temp => temp.Name.Contains(searchString)).ToList();
                 filteredCinemas = cinema.Where(temp => temp.Name.Contains(searchString)).ToList();
              
            }
            ViewBag.filteredMovies = filteredMovies;
            ViewBag.filteredCinemas = filteredCinemas;

            return View();
        }

        //Function which returns a specific movie along with its details 
        //uses the movie id as a parameter
        public ActionResult Detail(long id)
        {
            Movie movie = _context.Movies.Where(temp => temp.MovieID == id).FirstOrDefault();//returns the specific movie which matches the id
            var schedule = _context.Schedules.Where(temp=>temp.Movie == movie.Name).ToList();//returns the schedules cinemas of the movie
            return View(movie);
        }
        //Function which finds cinemas scheduled to be view a specfic movie
        //Retrieved cinemas are assigned to viewbags  
        public ActionResult Bookings(int id)
        {
            var movie = _context.Movies.Where(temp => temp.MovieID == id).FirstOrDefault();
            ViewBag.Movie = movie;
            var schedule = _context.Schedules.Where(temp => temp.Movie == movie.Name).ToList();//returns list of schedules of a specific movie
            var cinemas = _context.Cinemas.ToList();
            List<DateTime> date = new List<DateTime>();
            foreach (var datetime in schedule)
            {
                date.Add(datetime.Time);
            }
            ViewBag.DateTime = date;
            ViewBag.Cinemas = cinemas;
            ViewBag.Schedule = schedule;
            return View();
        }
        //Function which creates a booking form for the user to book movies
        public ActionResult CreateBooking(int id)
        {
            var schedule = _context.Schedules.Where(temp => temp.ScheduleID == id).FirstOrDefault();
            Bookings booking = new Bookings();
            booking.UserID = User.Identity.GetUserId();
            booking.Movie = schedule.Movie;
            booking.Cinema = schedule.Cinema;
            booking.Price = schedule.BookPrice;
            booking.Time = schedule.Time;
            return View(booking);
        }

        //Function which will pass the booking form and saves it in the database
        [HttpPost]
        public ActionResult CreateBooking(Bookings booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Returns Contact Page View
        public ActionResult Contact()
        {
            return View();
        }
    }
}