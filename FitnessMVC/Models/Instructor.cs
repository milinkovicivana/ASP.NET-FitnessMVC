using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessMVC.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(25)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(55)]
        public string Email { get; set; }

    }
}