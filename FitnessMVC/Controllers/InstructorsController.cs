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
            var instructors = _context.Instructors.ToList();

            return View(instructors);
        }
    }
}