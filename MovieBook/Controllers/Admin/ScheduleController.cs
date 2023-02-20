using MovieBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBook.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ScheduleController : Controller
    {
        // GET: Schedule
        ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            var schedules = _context.Schedules.ToList();
            return View(schedules);
        }

        public ActionResult Create()
        {
            List<Movie> movies = _context.Movies.ToList();
            List<Cinema> cinemas = _context.Cinemas.ToList();
            List<string> movieNames = new List<string>();
            List<string> cinemaNames = new List<string>();
            foreach(var movie in movies)
            {
                movieNames.Add(movie.Name);
            }
            foreach(var cinema in cinemas)
            {
                cinemaNames.Add(cinema.Name);
            }
            ViewBag.MovieNames = movieNames;
            ViewBag.CinemaNames = cinemaNames;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                _context.Schedules.Add(schedule);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(schedule);
        }

        public ActionResult Detail(int id)
        {
            var schedule = _context.Schedules.Where(temp => temp.ScheduleID == id).FirstOrDefault();
            return View(schedule);
        }

        public ActionResult Edit(long id)
        {
            var schedule = _context.Schedules.Where(temp => temp.ScheduleID == id).FirstOrDefault();
            return View(schedule);
        }

        [HttpPost]
        public ActionResult Edit(Schedule schedule)
        {
            var existingSchedule = _context.Schedules.Where(temp => temp.ScheduleID == schedule.ScheduleID).FirstOrDefault();
            existingSchedule.Movie = schedule.Movie;
            existingSchedule.Cinema = schedule.Cinema;
            existingSchedule.Time = schedule.Time;
            existingSchedule.BookPrice = schedule.BookPrice;
            if (ModelState.IsValid)
            {
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(schedule);
        }

        public ActionResult Delete(int id)
        {
            var schedule = _context.Schedules.Where(temp => temp.ScheduleID == id).FirstOrDefault();
            _context.Schedules.Remove(schedule);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}