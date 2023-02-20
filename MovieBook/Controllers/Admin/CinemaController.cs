using MovieBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieBook.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CinemasController : Controller
    {
        //Database connection
        ApplicationDbContext _context = new ApplicationDbContext();

        //Function which returns list of Cinemas 
        public ActionResult Index()
        {
            var cinemas = _context.Cinemas.ToList();
            return View(cinemas);
        }

        //Function which returns cinema detail; uses cinema id as a parameter
        public ActionResult Detail(int id)
        {
            var cinema = _context.Cinemas.Where(temp => temp.CinemaID == id).FirstOrDefault();
            return View(cinema);
        }

        public ActionResult Create()
        {
            return View();
        }

        //Function to Create 
        [HttpPost]
        public ActionResult Create(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                _context.Cinemas.Add(cinema);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cinema);

        }
        public ActionResult Edit(long id)
        {
            var cinema = _context.Cinemas.Where(temp => temp.CinemaID == id).FirstOrDefault();
            return View(cinema);
        }

        [HttpPost]
        public ActionResult Edit(Cinema cinema)
        {
            var existingCinema = _context.Cinemas.Where(temp => temp.CinemaID == cinema.CinemaID).FirstOrDefault();
            existingCinema.Logo = cinema.Logo;
            existingCinema.Name = cinema.Name;
            existingCinema.Description = cinema.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            var cinema = _context.Cinemas.Where(temp => temp.CinemaID == id).FirstOrDefault();
            _context.Cinemas.Remove(cinema);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}