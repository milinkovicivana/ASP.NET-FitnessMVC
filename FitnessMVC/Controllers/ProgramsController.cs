using FitnessMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FitnessMVC.ViewModels;
using System.IO;

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

        public ActionResult Details(int id)
        {
            var program = _context.Programs.SingleOrDefault(p => p.Id == id);

            if (program == null)
            {
                return HttpNotFound();
            }

            return View(program);
        }

        [Authorize(Roles = RoleName.CanManagePrograms + "," + RoleName.Admin)]       
        public ActionResult New()
        {
            var programTypes = _context.ProgramTypes.ToList();

            var viewModel = new ProgramFormViewModel
            {
                Program = new Program(),
                ProgramTypes = programTypes
            };

            return View("ProgramForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManagePrograms + "," + RoleName.Admin)]
        public ActionResult Save(Program program)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProgramFormViewModel
                {
                    Program = program,
                    ProgramTypes = _context.ProgramTypes.ToList()
                };

                return View("ProgramForm", viewModel);
            }

            foreach (string file in Request.Files)
            {
                HttpPostedFileBase img = Request.Files[file];
                if (img != null && img.ContentLength > 0)
                {
                    string imgFile = Path.GetFileName(img.FileName);
                    string path = "~/Content/Images/" + imgFile;
                    img.SaveAs(Server.MapPath(path));
                }
            }
            
            if (program.Id == 0)
            {                    
                 _context.Programs.Add(program);               
            }
            else
            {
                var programInDb = _context.Programs.Single(p => p.Id == program.Id);                

                programInDb.Name = program.Name;
                programInDb.Description = program.Description;
                programInDb.ProgramTypeId = program.ProgramTypeId;
                programInDb.Image = program.Image;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Programs");
        }

        [Authorize(Roles = RoleName.CanManagePrograms + "," + RoleName.Admin)]
        public ActionResult Edit(int id)
        {
            var program = _context.Programs.SingleOrDefault(p => p.Id == id);

            if (program == null)
            {
                return HttpNotFound();
            }

            var viewModel = new ProgramFormViewModel
            {
                Program = program,
                ProgramTypes = _context.ProgramTypes.ToList()
            };

            return View("ProgramForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManagePrograms + "," + RoleName.Admin)]
        public ActionResult Delete(int id)
        {
            var program = _context.Programs.Find(id);

            if (program == null)
            {
                return HttpNotFound();
            }

            _context.Programs.Remove(program);

            _context.SaveChanges();

            return RedirectToAction("Index", "Programs");
        }
    }
}