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
    public class SchedulesController : Controller
    {
        private ApplicationDbContext _context;

        public SchedulesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var schedule = _context.Schedules.Include(s => s.Program).Include( s => s.Instructor).ToList().OrderBy(s => s.Day).ThenBy(s => s.Time);
               
            return View(schedule);
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult New()
        {
            
            var viewModel = new ScheduleFormViewModel()
            {
                Schedule = new Schedule(),
                Programs = _context.Programs.ToList(),
                Instructors = _context.Instructors.ToList()
            };

            return View("ScheduleForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Save(Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ScheduleFormViewModel()
                {
                    Schedule = schedule,
                    Programs = _context.Programs.ToList(),
                    Instructors = _context.Instructors.ToList()
                };

                return View("ScheduleForm", viewModel);
            }

            if (schedule.Id == 0)
            {
                _context.Schedules.Add(schedule);
            }
            else
            {
                var scheduleInDb = _context.Schedules.Single(s => s.Id == schedule.Id);

                scheduleInDb.Day = schedule.Day;
                scheduleInDb.Time = schedule.Time;
                scheduleInDb.ProgramId = schedule.ProgramId;
                scheduleInDb.InstructorId = schedule.InstructorId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Schedules");
        }

        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var schedule = _context.Schedules.SingleOrDefault(s => s.Id == id);

            if (schedule == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ScheduleFormViewModel()
            {
                Schedule = schedule,
                Programs = _context.Programs.ToList(),
                Instructors = _context.Instructors.ToList()
            };

            return View("ScheduleForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Admin)]
        public ActionResult Delete(int id)
        {
            var schedule = _context.Schedules.Find(id);

            if (schedule == null)
            {
                return HttpNotFound();
            }

            _context.Schedules.Remove(schedule);

            _context.SaveChanges();

            return RedirectToAction("Index", "Schedules");
        }


    }
}