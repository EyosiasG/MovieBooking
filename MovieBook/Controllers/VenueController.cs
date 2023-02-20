using MovieBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MovieBook.Controllers
{
    public class VenueController : Controller
    {
        
        ApplicationDbContext _context = new ApplicationDbContext(); //Database Connection 

        //Function which returns list of Cinemas and returns them to the view as a list
        public ActionResult Index()
        {
            var cinemas = _context.Cinemas.ToList(); //returns the list of cinemas in the database
            return View(cinemas);
        }

        //Function which returns movies scheduled to be viewed in a cinema 
        public ActionResult Bookings(int id)
        {
            ViewBag.UserID = User.Identity.GetUserId();
            var cinema = _context.Cinemas.Where(temp => temp.CinemaID == id).FirstOrDefault();
            ViewBag.Cinema = cinema;
            var schedule = _context.Schedules.Where(temp => temp.Cinema == cinema.Name).ToList();
            List<string> scheduledMovies = new List<string>();

            foreach (var s in schedule)
            {
                scheduledMovies.Add(s.Movie);
            }
            var movies = _context.Movies.ToList();
            List<Movie> moviesScheduled = new List<Movie>(); //variable which will be used as viewbag to view list of scheduled movies in cinemas
            //list of movies scheduled to be viewed in a specfic cinema
            foreach (var movie in movies)
            {
                foreach(var s in schedule)
                {
                    if(movie.Name == s.Movie)
                    {
                        if(scheduledMovies.Any(temp => temp.Contains(movie.Name) == false))
                        {
                            moviesScheduled.Add(movie);
                        }
                    }
                      
                }
            }
     
            List<DateTime> date = new List<DateTime>();//time of scheduled movies which will be used as a viewbag to be viewed in the html page
            foreach(var datetime in schedule)
            {
                date.Add(datetime.Time);
            }
            ViewBag.DateTime = date;
            ViewBag.Movies = movies;
            ViewBag.Schedule = schedule;
            ViewBag.ScheduledMovies = scheduledMovies;
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


    }
}