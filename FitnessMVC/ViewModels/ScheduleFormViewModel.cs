using FitnessMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessMVC.ViewModels
{
    public class ScheduleFormViewModel
    {
        public IEnumerable<Program> Programs { get; set; }

        public IEnumerable<Instructor> Instructors { get; set; }

        public Schedule Schedule { get; set; }
    }
}