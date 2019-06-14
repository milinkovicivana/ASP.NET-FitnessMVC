using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessMVC.Models
{
    public class Schedule
    {
        public int Id { get; set; }

        [Required]
        public int Day { get; set; }

        [Required]
        [MaxLength(7)]
        public string Time { get; set; }

        [Display(Name = "Program")]
        public int ProgramId { get; set; }

        public Program Program { get; set; }

        [Display(Name = "Instructor")]
        public int InstructorId { get; set; }

        public Instructor Instructor { get; set; }
    }
}