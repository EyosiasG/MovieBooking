using MovieBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MovieBook.Controllers
{
    public class BookController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext(); //Database Connectio(Access)

        //Function which returns list of bookings made by all user(to be viewed only by the admin)
        public ActionResult Index()
        {
            var bookings = _context.Bookings.ToList();
            return View(bookings);
        }

        //Function which lets users delete bookings made by a user 
        public ActionResult Delete(int id)
        {
            var booking = _context.Bookings.Where(temp => temp.BookingID == id).FirstOrDefault();
            _context.Bookings.Remove(booking);
            _context.SaveChanges();
            if (HttpContext.User.IsInRole("Admin"))
                return RedirectToAction("Index");
            else
                return RedirectToAction("BookingList");
        }

        //Function which returns bookings made by a user
        public ActionResult BookingList()
        {
            var UserID = User.Identity.GetUserId();
            var bookings = _context.Bookings.Where(temp => temp.UserID == UserID).ToList();
            ViewBag.Movie = _context.Movies.ToList();
            return View(bookings);
        }

        
        public ActionResult AddBooking(int id)
        {
            var movie = _context.Movies.Where(temp => temp.MovieID == id).FirstOrDefault();
            List<Schedule> schedules = _context.Schedules.Where(temp => String.Compare(temp.Movie, movie.Name) == 0).ToList();
            ViewBag.MovieName = movie.Name;
            ViewBag.MovieImage = movie.ImageURL;
            ViewBag.MovieRating = movie.Ratings;
            ViewBag.MovieGenre = movie.Genre;
            var cinemas = _context.Cinemas.ToList();
            List<string> cinemaNames = new List<string>();
            foreach(var cinema in cinemas)
            {
                cinemaNames.Add(cinema.Name);
            }
            ViewBag.Cinema = cinemaNames;
            return View(schedules);
        }
        [HttpPost]
        public ActionResult AddBooking(string userID, int scheduleID)
        {
            var schedule = _context.Schedules.Where(temp => temp.ScheduleID == scheduleID).FirstOrDefault();
            Bookings booking = new Bookings();
            booking.UserID = userID;
            booking.Movie = schedule.Movie;
            booking.Cinema = schedule.Cinema;
            booking.Time = schedule.Time;
            booking.Price = schedule.BookPrice;
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return RedirectToAction("BookingList");
        }

       
    }
}