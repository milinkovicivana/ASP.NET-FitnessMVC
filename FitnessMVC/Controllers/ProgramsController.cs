using FitnessMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FitnessMVC.ViewModels;

namespace FitnessMVC.Controllers
{
    public class ProgramsController : Controller
    {
        private ApplicationDbContext _context;

        public ProgramsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var programs = _context.Programs.ToList();

            var types = _context.ProgramTypes.ToList();

            var ViewModel = new IndexProgramViewModel
            {
                Programs = programs,
                ProgramTypes = types
            };

            return View(ViewModel);
        }
    }
}