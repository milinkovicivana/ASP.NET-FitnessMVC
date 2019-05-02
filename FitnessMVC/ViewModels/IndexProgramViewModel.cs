using FitnessMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessMVC.ViewModels
{
    public class IndexProgramViewModel
    {
        public IEnumerable<ProgramType> ProgramTypes { get; set; }
        public IEnumerable<Program> Programs { get; set; }
    }
}