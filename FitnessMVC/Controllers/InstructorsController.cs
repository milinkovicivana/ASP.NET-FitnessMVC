using FitnessMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FitnessMVC.Controllers
{
    public class InstructorsController : Controller
    {
        private ApplicationDbContext _context;

        public InstructorsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var instructors = _context.Instructors.ToList().OrderByDescending(i => i.Id);

            return View(instructors);
        }

        public ActionResult New()
        {                    
            return View("InstructorForm", new Instructor());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Instructor instructor)
        {
            if (!ModelState.IsValid)
            {                
                return View("InstructorForm", instructor);
            }

            if (instructor.Id == 0)
            {
                _context.Instructors.Add(instructor);
            }
            else
            {
                var instructorInDb = _context.Instructors.Single(i => i.Id == instructor.Id);

                instructorInDb.Name = instructor.Name;
                instructorInDb.Phone = instructor.Phone;
                instructorInDb.Address = instructor.Address;
                instructorInDb.Email = instructor.Email;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Instructors");
        }

        public ActionResult Edit(int id)
        {
            var instructor = _context.Instructors.SingleOrDefault(i => i.Id == id);

            if (instructor == null)
            {
                return HttpNotFound();
            }
          
            return View("InstructorForm", instructor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var instructor = _context.Instructors.Find(id);

            if (instructor == null)
            {
                return HttpNotFound();
            }

            _context.Instructors.Remove(instructor);

            _context.SaveChanges();

            return RedirectToAction("Index", "Instructors");
        }
    }
}