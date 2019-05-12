using FitnessMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessMVC.ViewModels
{
    public class ProgramFormViewModel
    {
        public IEnumerable<ProgramType> ProgramTypes { get; set; }
        public Program Program { get; set; }
    }
}